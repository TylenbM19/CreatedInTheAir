using System;
using System.Collections.Generic;
using System.Linq;

public abstract class State
{
    private List<Transition> _transitions;

    public event Action<State> NeedChangeState;

    public void SetTransitions(params Transition[] transitions)
    {
        _transitions = transitions.ToList();
    }

    public virtual void Enter()
    {
        SubscribeOnTransitions();
        EnableTransitions();
    }

    public virtual void Exit() 
    {
        UnsubscribeOnTransitions();
        DisableTransitions();
    }
    
    public  void Update() 
    {

    }

    private void SubscribeOnTransitions()
    {
        if (_transitions == null)
            return;

        foreach (Transition transition in _transitions)
        {
            transition.NeedChangeState += ChangeState;
        }
    }

    private void UnsubscribeOnTransitions()
    {
        if (_transitions == null)
            return;

        foreach (Transition transition in _transitions)
        {
            transition.NeedChangeState -= ChangeState;
        }
    }
    private void EnableTransitions()
    {
        foreach (Transition transition in _transitions)
        {
            transition.Enable();
        }
    }

    private void DisableTransitions()
    {
        foreach (Transition transition in _transitions)
        {
            transition.Disable();
        }
    }

    public void ChangeState(State nextState)
    {
        NeedChangeState?.Invoke(nextState);
    }
}
