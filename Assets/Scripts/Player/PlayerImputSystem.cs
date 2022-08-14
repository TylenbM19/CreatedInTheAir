using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerImputSystem : MonoBehaviour
{
    private PlayerInput _playerInput;


    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
