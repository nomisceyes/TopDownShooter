using System;
using UnityEngine;
using static PlayerAnimations;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimations))]

public class PlayerMovement : MonoBehaviour
{
    readonly private string Horizontal = "Horizontal";
    readonly private string Vertical = "Vertical";

    private CharacterController _characterController;

    private Vector2 _movement;

    private float _movementSpeed = 6f;
    private bool _isFlipped = true;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        float verticalInput = Input.GetAxis(Vertical);

        _movement.x = horizontalInput * _movementSpeed;
        _movement.y = verticalInput * _movementSpeed;

        _movement = Vector2.ClampMagnitude(_movement, _movementSpeed);

        Flip();
        IsMoving(_movement.sqrMagnitude);

        _movement *= Time.deltaTime;
        _characterController.Move(_movement);
    }

    private void Flip()
    {
        if ((_movement.x > 0 && !_isFlipped) || (_movement.x < 0 && _isFlipped))
        {           
            _isFlipped = !_isFlipped;
            transform.Rotate(0f, 180f,0f);
        }
    }
}