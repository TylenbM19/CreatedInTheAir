using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private InputSystem _inputSystem;
    private Vector2 _direction;
    public static Action<float, float> ChangeAxis;


    private void Awake()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Enable();
    }

    private void FixedUpdate()
    {
        _direction = _inputSystem.Player.Move.ReadValue<Vector2>();
        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;


        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
        ChangeAxis?.Invoke(direction.x, direction.y);
    }
}
