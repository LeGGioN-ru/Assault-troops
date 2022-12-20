using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (Transition transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            enabled = false;

            foreach (Transition transition in _transitions)
                transition.enabled = false;
        }
    }

    public State TryGetNextState()
    {
        foreach (Transition transition in _transitions)
            if (transition.IsNeedTransit == true)
                return transition.TargetState;

        return null;
    }
}
