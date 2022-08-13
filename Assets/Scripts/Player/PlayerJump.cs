using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(LayerMask))]
[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _forseJump;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private PlayerInput _playerIntput; 
    private CharacterController characterController;
    private bool _onGround;
    private float _checkRadius = 0.1f;

    private void Awake()
    {
        _playerIntput = new PlayerInput();
        _playerIntput.Player.Jump.performed += ctx => Jump();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
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
        //if(_onGround)
        characterController.Move(Vector3.up * _forseJump);
    }

    private void ChekingGround()
    {
        _onGround = Physics.CheckSphere(_groundCheck.position, _checkRadius, _groundMask);
        Debug.Log(_onGround);
    }
}
