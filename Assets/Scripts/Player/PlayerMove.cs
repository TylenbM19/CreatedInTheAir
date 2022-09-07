using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private InputSystem _inputSystem;
    private Vector2 _direction;
    private CharacterController _characterController;
    private Transform _transform;

    public static event UnityAction <Vector2> ChanseAxis;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Enable();
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _direction = _inputSystem.Player.Move.ReadValue<Vector2>();

        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        _characterController.Move(move * scaledMoveSpeed);
        ChanseAxis?.Invoke(direction);
    }
}
