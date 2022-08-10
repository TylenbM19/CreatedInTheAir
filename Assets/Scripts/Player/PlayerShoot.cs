using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class PlayerShoot : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;
    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Shoot.performed += ctx => OnShoot();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
 
    public void OnShoot()
    {
        _animator.Play("Attack");
        Debug.Log("Shoot");
    }
}
