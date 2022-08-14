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
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _checkGround;
    [SerializeField] private LayerMask _groundMask;

    private StateMashina _stateMashine;
    private PlayerIdleState _idleState;
    private PlayerRunState _runState;
    private PlayerShootState _shootState;
    private PlayerJumpState _jumpState;
    private Animator _animator;
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private bool _onGround;
    private float _checkRadius = 0.1f;

    public int Money { get; private set; }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _stateMashine = new StateMashina();
        _idleState = new PlayerIdleState(_animator);
        _runState = new PlayerRunState(_animator, _playerInput, _moveSpeed, _characterController, transform);
        _shootState = new PlayerShootState(_animator, _playerInput, _weapon);
        _jumpState = new PlayerJumpState();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _stateMashine.Initialize(_runState);
    }

    private void Update()
    {
        _stateMashine.Update();     
    }

    private void FixedUpdate()
    {
        ChekingGround();
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    private void ChekingGround()
    {
        _onGround = Physics.CheckSphere(_checkGround.position, _checkRadius, _groundMask);
        Debug.Log(_onGround);
    }
}
