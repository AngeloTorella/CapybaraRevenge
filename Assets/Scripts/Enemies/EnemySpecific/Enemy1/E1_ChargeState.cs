using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;

    public E1_ChargeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        base.LogicUpdate();

        if (!isDetectingLedge || isDetectingWall) 
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isChargeTimeOver) 
        {
            if(performCloseRangeAction){
                stateMachine.ChangeState(enemy.meleeAttackState);
                
            } else if (isPlayerInMinAgroRange)
            { 
                //Este if deberia ser para el ataque, pero aun no he agregado las variables acorde al ataque
                stateMachine.ChangeState(enemy.chargeState);
            }
            else 
            {
                //Este if lo agregue yo para que funcione bien la perdida del agro, lo puedes quitar si lo ves bien con la lista de reproduccion
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

