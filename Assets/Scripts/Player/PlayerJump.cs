using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(LayerMask))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _forseJump;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private bool _onGround;
    private float _checkRadius = 0.1f;
    private PlayerInput _playerIntput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerIntput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody>();
        _playerIntput.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable()
    {
        _playerIntput.Enable();
    }

    private void OnDisable()
    {
        _playerIntput.Disable();
    }

    private void FixedUpdate()
    {
        ChekingGround();
    }

    private void Jump()
    {
        if(_onGround)
        _rigidbody.velocity = Vector3.up * _forseJump;
    }

    private void ChekingGround()
    {
        _onGround = Physics.CheckSphere(_groundCheck.position, _checkRadius, _groundMask);
        Debug.Log(_onGround);
    }
}
