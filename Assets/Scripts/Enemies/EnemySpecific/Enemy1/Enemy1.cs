using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : Entity
{
    //-- ENEMY STATES --//
    public E1_IdleState idleState {  get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetected playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    public E1_MeeleAttackState meleeAttackState {get; private set;}
    public E1_DeadState deadState { get; private set; }

    //-- STATES DATA OBJECTS --//
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState ChargeData;
    [SerializeField]
    private D_LookForPlayerState LookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;


    //-- METHODS --//
    public override void Start()
    {
        base.Start();

        //-- INITILIZE ALL STATES --//
        //Aqui estoy registrando todos mis estados, mis dependencias con los states
        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetected(this, stateMachine,"playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", ChargeData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine,"lookForPlayer", LookForPlayerStateData, this);
        deadState = new E1_DeadState(this, stateMachine,"dead", deadStateData, this);
        //Falta inicializar el ataque...
        meleeAttackState = new E1_MeeleAttackState(this,stateMachine, "meleeAttack", meleeAttackPosition,meleeAttackStateData,this);

        stateMachine.Initialize(moveState);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);

            Destroy(gameObject);
        }
    }
}
