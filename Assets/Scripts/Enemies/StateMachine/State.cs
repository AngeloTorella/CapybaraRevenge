using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encargara de definir la abstraccion de cada uno de los estados que puede tener un enemigo
/// </summary>
public abstract class State{
    
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
}
