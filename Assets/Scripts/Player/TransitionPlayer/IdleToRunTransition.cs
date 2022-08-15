using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleToRunTransition : Transition
{
    private PlayerImputSystem _playerImputSystem;

    public IdleToRunTransition(State nextState,PlayerImputSystem playerImputSystem) : base(nextState)
    {
        _playerImputSystem = playerImputSystem;
    }
}
