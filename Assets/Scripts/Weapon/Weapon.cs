using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bullet;

    private ObjectPool<Bullet> _weaponShop;
    private int _poolCapacity = 1;
    private int _poolMaxSize = 10;
    private int _lifeTime = 1;

    protected Transform FirePoint { get => _firePoint; private set => _firePoint = FirePoint; }
    protected int PoolCapacity { get => _poolCapacity; private set => _poolCapacity = PoolCapacity; }
    protected int PoolMaxSize { get => _poolMaxSize; private set => _poolMaxSize = PoolMaxSize; }

    private void Start()
    {
        _weaponShop = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_bullet, _firePoint.position, _firePoint.rotation),
            actionOnGet: (obj) => _bullet.BulletFly(),
            actionOnRelease: (obj) => _bullet.gameObject.SetActive(true),
            actionOnDestroy: (obj) => Destroy(_bullet),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        ); 
    }

    private void Update()
    {       
        Shoot();
    }

    protected virtual void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Invoke(nameof(GetBullet), 0.0f);       
        }
    }

    protected void GetBullet()
    {
        _weaponShop.Get();
    }

    private void Release()
    {
        _weaponShop.Release(_bullet);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifeTime);

        Release();
    }
}