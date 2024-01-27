using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData; 

    public int facingDirection { get; private set; }
    public Animator anim { get; private set; }   
    public Rigidbody2D  rb { get; private set; }

    public AnimationToStateMachine atsm {get; private set;}

    //-- GAME OBJECTS DEPENDENCIES --//
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform PlayerCheck;
    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        facingDirection = 1;

        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        atsm = this.GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity) 
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall() 
    {
        return Physics2D.Raycast(wallCheck.position, this.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange() 
    {
        return Physics2D.Raycast(PlayerCheck.position, this.transform.right, entityData.MinAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange() 
    {
        return Physics2D.Raycast(PlayerCheck.position, this.transform.right, entityData.MaxAgroDistance, entityData.whatIsPlayer);
    }

    /// <summary>
    /// Esta funcion se encarga de verificar si el player se encuentra dentro del rango de ataque del enemigo
    /// </summary>
    /// <returns></returns>
    public virtual bool CheckPlayerInCloseRangeAction(){
        //Que es el Layer Mask
        return Physics2D.Raycast(PlayerCheck.position, this.transform.right, entityData.CloseRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void Flip() 
    {
        facingDirection *= -1;
        this.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }
}
