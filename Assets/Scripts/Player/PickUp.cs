using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animCurve;
    [SerializeField] private float _pickUpDistance = 5f;
    [SerializeField] private float _accelerationRate = 0.2f;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _heighY = 1.5f;
    [SerializeField] private float _popDuration = 1f;

    private Vector3 _moveDirection;
    private Rigidbody2D _rigidbody;
    private Transform _playerPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }

    private void Update()
    {
        Vector3 playerPos = _playerPosition.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < _pickUpDistance)
        {
            _moveDirection = (playerPos - transform.position).normalized;
            _moveSpeed += _accelerationRate;
        }
        else
        {
            _moveDirection = Vector3.zero;
            _moveSpeed = 0f;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveSpeed * Time.deltaTime * _moveDirection;
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;

        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new(randomX, randomY);

        float timePassed = 0f;

        while (timePassed < _popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / _popDuration;
            float heightT = _animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, _heighY, heightT);

            transform.position = Vector2.Lerp(startPoint,endPoint,linearT) + new Vector2(0f,height);
            yield return null;
        }
    }
}