using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerImputSystem : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void AddShootListener(Action<InputAction.CallbackContext> callbackContext)
    {
        _playerInput.Player.Shoot.performed += callbackContext;
    }

    public void RemoveShootListener(Action<InputAction.CallbackContext> callbackContext)
    {
        _playerInput.Player.Shoot.performed -= callbackContext;
    }

    public  void AddJumpListener(Action<InputAction.CallbackContext> callbackContext)
    {
        _playerInput.Player.Jump.performed += callbackContext;
    }

    public void RemoveJumpListener(Action<InputAction.CallbackContext> callbackContext)
    {
        _playerInput.Player.Jump.performed -= callbackContext;
    }
}
