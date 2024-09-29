using UnityEngine;
using UnityEngine.Pool;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected AudioClip _audioClip;

    protected bool _isCharged = true;

    protected AudioSource AudioSource { get; private set; }
    protected Transform FirePoint { get => _firePoint; private set => _firePoint = FirePoint; }
    public float TimeOfReload { get; protected set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        TimeOfReload = 0.3f;
        AudioSource.clip = _audioClip;
    }

    private void Update()
    {
        Shoot();
    }

    protected virtual void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && _isCharged)
        {
            AudioSource.Play();
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            AudioSource.Stop();
            StartCoroutine(Reload());
        }
    }

    protected IEnumerator Reload()
    {
        _isCharged = false;

        yield return new WaitForSeconds(TimeOfReload);

        _isCharged = true;
    }
}