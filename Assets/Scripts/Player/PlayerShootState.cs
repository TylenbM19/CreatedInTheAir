using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : State
{
    private const string ShootAnimation = "Shoot";
    private Animator _animator;
    private PlayerInput _playerInput;
    private Weapon _weapon;

    public PlayerShootState(Animator animator,PlayerInput playerInput,Weapon weapon)
    {
        _animator = animator;
        _playerInput = playerInput;
        _weapon = weapon;
    }

    public override void Enter()
    {
        //_animator.Play(ShootAnimation);
    }

    public override void Update()
    {
        _playerInput.Player.Shoot.performed += ctx => OnShoot();
    }

    public void OnShoot()
    {
        _weapon.Shoot();
        Debug.Log("shoot");
    }
}
