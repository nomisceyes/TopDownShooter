using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GameObject _particles;

    private static Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static void IsMoving(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void IsDeath()
    {
        Instantiate(_particles,transform.position,transform.rotation);
        _animator.SetTrigger("IsDeath");    
    }
}