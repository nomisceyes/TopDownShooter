using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyAnimations),
                  typeof(NavMeshAgent),
                  typeof(DropLogic))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject _enemySO;
    [SerializeField] private int _health;

    private Transform _player;
    private NavMeshAgent _agent;
    private SpriteRenderer _spriteRenderer;
    private EnemyAnimations _enemyAnimations;
    private DropLogic _dropLogic;
    private PlayerHealth _playerHealth;

    private Vector2 _startPosition;

    public bool IsAlive { get; private set; }

    public static event Action OnTakedDamage;
    public static event Action OnDead;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _dropLogic = GetComponent<DropLogic>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Start()
    {
        _health = _enemySO.Health;
        _agent.speed = _enemySO.Speed;
        _agent.stoppingDistance = _enemySO.AttackRange;
        _startPosition = transform.position;
        IsAlive = true;
    }

    private void FixedUpdate()
    {
        if (_playerHealth.IsAlive && _health > 0)
            MoveTo(_player.position);
        else
            MoveTo(_startPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerHealth>().IsAlive)
        {
            OnTakedDamage?.Invoke();
        }
    }

    private void ChangeFacingDirection(Vector2 target) => _spriteRenderer.flipX = transform.position.x > target.x;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            IsAlive = false;
            StartCoroutine(RemoveEnemy());
        }
        else
        {
            _enemyAnimations.IsHitting();
        }
    }

    private void MoveTo(Vector2 target)
    {
        _agent.SetDestination(target);
        ChangeFacingDirection(target);
    }

    private IEnumerator RemoveEnemy()
    {
        GetComponent<Collider2D>().enabled = false;
        OnDead?.Invoke();

        _enemyAnimations.IsDeath();
        _dropLogic.Drop();
        _agent.isStopped = true;

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}