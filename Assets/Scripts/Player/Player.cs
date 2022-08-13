using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<IItem> _items;
    [SerializeField] private float _moveSpeed;

    private StateMashina _stateMashine;
    private PlayerIdleState _idleState;
    private PlayerRunState _runState;
    private Animator _animator;
    private PlayerInput _playerInput;
    private CharacterController _characterController;

    public int Money { get; private set; }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _stateMashine = new StateMashina();
        _idleState = new PlayerIdleState(_animator);
        _runState = new PlayerRunState(_animator, _playerInput, _moveSpeed, _characterController, transform);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _stateMashine.Update();
    }

    private void Start()
    {
        _stateMashine.Initialize(_runState);
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void Idle()
    {
        _stateMashine.ChangeState(_idleState);
    }
}
