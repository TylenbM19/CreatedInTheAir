using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void Enter();

    public virtual void Exit() { }
    
    public virtual void Update() { }
}
