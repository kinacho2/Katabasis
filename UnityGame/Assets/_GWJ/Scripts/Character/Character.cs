using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ColliderInteractions Collider;

    public Vector3 Velocity;
    public Vector2 Direction;

    [SerializeField] public CharacterInput Joystick;
    [SerializeField] public SpriteRenderer Renderer;

    [SerializeField] InvulnerabilityState InvulnerabilityState;
    public void Hurt()
    {
        if (!InvulnerabilityState.Invulnerability)
        {
            InvulnerabilityState.Invulnerability = State.Damage();
        }
    }

    [SerializeField] public Animator Animator;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] public CharacterState State;
    [SerializeField] public Statistics Statistics;


    public void ChangeState(CharacterState st)
    {
        if (st != State)
        {
            var s = State;
            st.StateEnter(s);
            State = st;
            Debug.LogError("State" + st.name);

        }
    }

    private void FixedUpdate()
    {
        //if(!semaphore)
        State.CustomUpdate(Time.fixedDeltaTime);

        if (Velocity.magnitude > .1f)
        {

            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
           // Rigidbody.MovePosition(transform.position + new Vector3(0, Velocity.y * Time.fixedDeltaTime, 0));
        }

    }

    private void Update()
    {
        if (Joystick.inputReader.Stick.x > 0)
        {
            Renderer.flipX = false;
            Direction = new Vector2(1, 0);
        }
        if (Joystick.inputReader.Stick.x < 0)
        {
            Renderer.flipX = true;
            Direction = new Vector2(-1, 0);
        }
        

    }


}
