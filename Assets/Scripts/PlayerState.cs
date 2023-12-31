using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;

    private string aniBoolName;

    protected float stateTimer;
    protected bool triggerCalled;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _aniBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.aniBoolName = _aniBoolName;

    }
    public virtual void Enter()
    {
        player.anim.SetBool(aniBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(aniBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}

