using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta Clase se va a encargar de llevar un traking de el State en el que se encuentra un enemigo y correr
/// El codigo correcto para cada estado
/// </summary>
public class FiniteStateMachine
{
   public State currentState {get; private set;}

   public void Initialize(State startingState){
    //Primer Estado al iniciar el juego
    currentState = startingState;
   }
}
