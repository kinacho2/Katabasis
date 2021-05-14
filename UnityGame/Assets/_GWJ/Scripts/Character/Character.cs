﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool Grounded;
    public bool Topped;

    public Vector3 Velocity;

    [SerializeField] public CharacterInput Joystick;
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
            Debug.LogError("State" + st.GetType().Name);

        }
    }

    private void FixedUpdate()
    {
        State.CustomUpdate(Time.fixedDeltaTime);

        if (Velocity.magnitude > .1f)
        {

            transform.position = transform.position + Velocity * Time.fixedDeltaTime;
           // Rigidbody.MovePosition(transform.position + new Vector3(0, Velocity.y * Time.fixedDeltaTime, 0));
        }

    }


}