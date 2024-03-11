using UnityEngine;

[RequireComponent(typeof(Solider))]
public class SoliderStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State CurrentState => _currentState;

    private void OnEnable()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.TryGetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        if (_currentState != null)
            _currentState.enabled = false;

        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter();
    }
}
