using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public static void IsMoving(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}