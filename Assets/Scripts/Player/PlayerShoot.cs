using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public static Action onShooting;

    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void Update()
    {
        _inputSystem.Player.Shoot.performed += ctx => OnShoot();
    }

    private void OnShoot()
    {
        //_weapon.Shoot();
        //Debug.Log("я стрельнул");
        onShooting?.Invoke();
    }
}
