using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta Clase se va a encargar de llevar un traking de el State en el que se encuentra un enemigo y correr
/// El codigo correcto para cada estado
/// </summary>
public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
