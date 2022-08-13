using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : State
{
    private const string RunAnimation = "Idle-Run";
    private const string SpeedAnimation = "Speed";
    private const float RunSpeed = 1;
    private float _moveSpeed;
    private Animator _animator;
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Transform _transform;

    public PlayerRunState(
        Animator animator, 
        PlayerInput playerInput, 
        float moveSpeed,   
        CharacterController characterController,
        Transform transform)
    {
        _animator = animator;
        _playerInput = playerInput;
        _moveSpeed = moveSpeed;
        _characterController = characterController;
        _transform = transform;
    }

    public override void Enter()
    {
        _animator.Play(RunAnimation);
        _animator.SetFloat(SpeedAnimation, RunSpeed);
    }

    public override void Update()
    {
        Vector2 direction = _playerInput.Player.Move.ReadValue<Vector2>();
        _animator.SetFloat(SpeedAnimation, direction.sqrMagnitude);

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        _characterController.Move(move * scaledMoveSpeed);
    }
}
