using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State
{
    private const string AnimationJump = "Jump";
    private Animator _animator;
    private bool _onCheckGroud;
    private CharacterController _characterController;
    private float _forseJump;

    public PlayerJumpState(Animator animator, bool onCheckGround, CharacterController characterController,float forseJump)
    {
        _characterController = characterController;
        _animator = animator;
        _onCheckGroud = onCheckGround;
        _forseJump = forseJump;
    }

    public void Update()
    {
        OnJump();
    }


    public void Enter()
    {
        _animator.Play(AnimationJump);
    }

    private void OnJump()
    {
        if (_onCheckGroud)
        {
            _characterController.Move(Vector3.up * _forseJump);
        }
    }
}
