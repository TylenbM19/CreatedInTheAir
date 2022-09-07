using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _direction1 = Vector2.zero;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerMove.ChanseAxis += Move;
    }

    private void Update()
    {
        Move(_direction1);
    }


    private void Move(Vector2 _direction)
    {
        _animator.SetFloat("Y", _direction.y, 0.2f, Time.deltaTime * 0.8f);
        _animator.SetFloat("X", _direction.x, 0.2f, Time.deltaTime * 0.8f);
    }
}
