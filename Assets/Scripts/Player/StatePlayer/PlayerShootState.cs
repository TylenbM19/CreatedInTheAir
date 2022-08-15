using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : State
{
    private const string ShootAnimation = "Shoot";
    private Animator _animator;
    private Weapon _weapon;

    public PlayerShootState(Animator animator,Weapon weapon)
    {
        _animator = animator;
        _weapon = weapon;
    }

    public void Enter()
    {
    }

    public void Update()
    {
        OnShoot();
    }

    public void OnShoot()
    {
        _weapon.Shoot();
        Debug.Log("shoot");
    }
}
