using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAfterAirJump : AirState
{

    float MoveFriction;
    [SerializeField] float EndMoveFriction;

    private void Awake()
    {
        MoveFriction = Statistics.Friction;
    }

    public override void StateEnter(CharacterState prevState)
    {
        base.StateEnter(prevState);
        if (name == "FallAfterAirJump")
            Debug.LogError("previo " + prevState.name);
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        if (Mathf.Abs(Character.Joystick.inputReader.Stick.x) < .1f)
        {
            if (Mathf.Abs(Character.Velocity.x) > .1f)
            {
                Statistics.Friction = EndMoveFriction;
            }
        }
        else
        {
            var vel = new Vector2(Character.Velocity.x, Character.Velocity.y);
            if (Vector2.Dot(Character.Joystick.inputReader.Stick, vel) >= 0
                || Character.Velocity.magnitude == 0)
            {
                Statistics.Friction = MoveFriction;
            }
            else
            {
                Statistics.Friction = EndMoveFriction;
            }

        }

        UpdateMove(deltaTime);
        if (Character.Collider.Bottom)
            EndState();
    }
}
