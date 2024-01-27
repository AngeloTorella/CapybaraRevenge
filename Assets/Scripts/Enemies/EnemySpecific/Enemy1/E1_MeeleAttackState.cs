using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeeleAttackState : MeleeAttackState
{
   public Enemy1 enemy;

    public E1_MeeleAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Enemy1 enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        //Aqui vamos a implementar la logica de la transicion de las animaciones.
        base.LogicUpdate();
        if(isAnimationFinished){
            if(isPlayerInMinAgroRange){
                stateMachine.ChangeState(enemy.playerDetectedState);
            } else {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
