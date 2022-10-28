public class StateMachine
{
    internal State CurrentState { get; set; }

    internal void Initialize(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    internal void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

}
