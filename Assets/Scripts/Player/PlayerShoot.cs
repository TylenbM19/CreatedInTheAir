using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private Weapon _weapon;
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
        _weapon.Shoot(_shootPoint);
        _animator.Play("Attack");
        Debug.Log("Shoot");
    }
}
