using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    readonly private float _speed = 15f;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Rigidbody2D _rigidbody;  

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    public void BulletFly()
    {
        _rigidbody.velocity = transform.right * _speed;
    }
}