using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter();

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }
}
