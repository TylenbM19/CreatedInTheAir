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
    }

    public virtual void Exit() 
    {
        UnsubscribeOnTransitions();
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

    public void ChangeState(State nextState)
    {
        NeedChangeState?.Invoke(nextState);
    }
}
