using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Rigidbody2D _rigidbody;

    private readonly float _speed = 15f;
    private readonly float _lifetime = 0.7f;

    public int Damage { get; protected set; }

    private void Awake()
    {
        Damage = 3;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<Enemy>().IsAlive)
        {
            collision.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifetime);

        Destroy(gameObject);
    }
}