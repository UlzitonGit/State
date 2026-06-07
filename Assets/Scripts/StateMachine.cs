using System;
using System.Collections.Generic;

public class StateMachine
{
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();
    private IState currentState;
    
    public IState CurrentState => currentState;
    
    public void AddState(IState state)
    {
        if (state == null)
            throw new ArgumentNullException(nameof(state));
            
        Type stateType = state.GetType();
     
            
        states[stateType] = state;
    }
    
    public void ChangeState<T>() where T : IState
    {
        ChangeState(typeof(T));
    }
    
    public void ChangeState(Type stateType)
    {
            
        if (!states.TryGetValue(stateType, out IState newState))
            return;
            
        if (currentState != null && currentState.GetType() == stateType)
            return;
            
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    
    public void Update()
    {
        currentState?.Update();
    }
    
    public T GetState<T>() where T : IState
    {
        if (states.TryGetValue(typeof(T), out IState state))
            return (T)state;
        return default;
    }
    
    public IState GetCurrentState()
    {
        return currentState;
    }
    
    public bool IsInState<T>() where T : IState
    {
        return currentState is T;
    }
}