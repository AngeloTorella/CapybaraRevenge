using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState {  get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetected playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }

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

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetected(this, stateMachine,"playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", ChargeData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine,"lookForPlayer", LookForPlayerStateData, this);

        stateMachine.Initialize(moveState);
    }
}