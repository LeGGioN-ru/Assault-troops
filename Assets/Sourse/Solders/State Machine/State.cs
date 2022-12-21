using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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

    protected void PlayAnimation(int animationIndex)
    {
        _animator.Play(animationIndex);
    }
}
