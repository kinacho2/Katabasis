using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    public ColliderInteractions Collider;

    public Vector3 Velocity;
    public Vector2 Direction;

    [SerializeField] public CharacterInput Joystick;
   
    [SerializeField] InvulnerabilityState InvulnerabilityState;

    [SerializeField] public SpriteRenderer Renderer;
    [SerializeField] public Animator Animator;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] public CharacterState State;
    [SerializeField] public Statistics Statistics;

     
    public bool Dead { get; protected set; }

    private void Start()
    {
        Dead = false;
    }

    public void ChangeState(CharacterState st)
    {
        if (st != State)
        {
            var s = State;
            st.StateEnter(s);
            State = st;

        }
    }

    private void FixedUpdate()
    {
        //if(!semaphore)
        State.CustomUpdate(Time.fixedDeltaTime);

        if (Velocity.magnitude > .1f)
        {

            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
       
        }
        Rigidbody.velocity = Vector2.zero;
    }

    internal void Death()
    {
        Dead = true;
    }

    public override bool Hurt(float value, Vector3 position, Vector2 Retroceso)
    {
        if (!InvulnerabilityState.Invulnerability)
        {
            if (GameManager.Instance)
                GameManager.Instance.Damage(this);
            InvulnerabilityState.Invulnerability = State.Damage(position, Retroceso);
            if (InvulnerabilityState.Invulnerability)
                return base.Hurt(value, position, Retroceso);
        }
        return false;
        
    }
    private void Update()
    {
        if (Dead) return;
        if (Joystick.inputReader.Stick.x > 0)
        {
            //Renderer.flipX = false;
            Direction = new Vector2(1, 0);
        }
        if (Joystick.inputReader.Stick.x < 0)
        {
            //Renderer.flipX = true;
            Direction = new Vector2(-1, 0);
        }
        var rot = transform.rotation;
        var rt = rot.eulerAngles;
        rt.y = (Direction.x < 0) ? 180: 0;
        rot.eulerAngles = rt;
        transform.rotation = rot;


    }


}
