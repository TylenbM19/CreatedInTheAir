using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashina 
{
    private State _currentState;


    public void Initialize(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }
}
