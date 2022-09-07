using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private const string AnimationRun = "Run";
    private const string AnimationBackwards = "Backwards";
    private const string AnimationIdle = "Idle";
    private const string AnimationNormalShoot = "NormalShoot";
    private const string AnimationForseShoot = "ForseShoot";
    private const string AnimationDie = "Die";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.OnDie += Die;
        Player.OnShoot += Shoot;
    }

    private void Move(float x, float y)
    {
        if (y < 0)
            _animator.Play(AnimationBackwards);

        else if (x >= 0 || y >= 0)
            _animator.Play(AnimationRun);

    }

    private void Shoot(int shotParameter)
    {
        switch (shotParameter)
        {
            case 1:
                _animator.Play(AnimationNormalShoot);
                break;
            case 2:
                _animator.Play(AnimationForseShoot);
                break;
        }
    }

    private void Die()
    {
        _animator.Play(AnimationDie);
    }
}
