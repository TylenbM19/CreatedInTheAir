using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition 
{
    private State _nextState;

    public Transition(State nextState)
    {
        _nextState = nextState;
    }

    public event Action<State> NeedChangeState;

    public virtual void Enable()
    {

    }

    public virtual void Disable()
    {

    }

    protected void MoveNextState()
    {
        NeedChangeState?.Invoke(_nextState);
    }
}
