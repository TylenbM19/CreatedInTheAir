using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashina 
{
    private State _firstState;
    private State _currentState;

    public void Initialize(State startState)
    {
        _firstState = startState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        if (_currentState == newState)
            return;

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState == null)
            return;

        _currentState.Update();
    }
}
