using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    private const string IdleAnimation = "Idle-Run";
    private const string SpeedAnimation = "Speed";
    private const float IdleSpeed = 0;
    private Animator _animator;

    public PlayerIdleState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.Play(IdleAnimation);
        _animator.SetFloat(SpeedAnimation, IdleSpeed);
    }
}
