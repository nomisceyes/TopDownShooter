using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public  void IsDeath()
    {
        _animator.SetTrigger("IsDeath");
    }

    public  void IsHitting()
    {
        _animator.SetTrigger("IsHitting");
    }
}
