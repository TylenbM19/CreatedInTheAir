using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleToShootTransition : Transition
{
    private PlayerImputSystem _playerImputSystem;

    public IdleToShootTransition(State nextState, PlayerImputSystem playerImputSystem) : base(nextState)
    {
        _playerImputSystem = playerImputSystem;
        _playerImputSystem.AddShootListener(OnShoot);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        MoveNextState();
    }
}
