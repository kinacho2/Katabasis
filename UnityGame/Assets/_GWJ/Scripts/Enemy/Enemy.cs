using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] public Vector3 Direction;
    [SerializeField] public float Speed = 3;
    [SerializeField] public float Gravity = 3;

    public ColliderInteractions Collider;

    [SerializeField] float damage = 1;
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] public Animator Animator;
    [SerializeField] public SpriteRenderer Renderer;

    internal void Attack(Character character)
    {
        
    }

    [SerializeField] public EnemyState State;
    [SerializeField] public Statistics Statistics;


    public void ChangeState(EnemyState st)
    {
        if (st != State)
        {
            var s = State;
            st.StateEnter(s);
            State = st;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Character = collision.collider.GetComponent<Character>();

        if (Character)
        {
            Character.Hurt(damage, transform.position);
        }
    }

    private void FixedUpdate()
    {
        State.CustomUpdate(Time.fixedDeltaTime);

        State.Move(Time.fixedDeltaTime);
    }

    public override bool Hurt(float value, Vector3 position)
    {
        return State.Damage(position);
    }

    private void Update()
    {
        Renderer.flipX = Direction.x > 0;
    }

}
