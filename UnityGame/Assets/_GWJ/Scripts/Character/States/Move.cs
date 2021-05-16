using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : GroundedState
{

    float MoveFriction;
    [SerializeField] float EndMoveFriction;

    private void Awake()
    {
        MoveFriction = Statistics.Friction;
    }

    public override void CustomUpdate(float deltaTime)
    {
        if (Character.Joystick.inputReader.OnJump)
            Character.ChangeState(Jump);
        if (Character.Joystick.inputReader.OnAttack)
            Character.ChangeState(Attack);
        if (Character.Joystick.inputReader.OnRoll)
            Character.ChangeState(Roll);


        if (Mathf.Abs(Character.Joystick.inputReader.Stick.x) < .1f)
        {
            if (Mathf.Abs(Character.Velocity.x) > .1f)
            {
                Statistics.Friction = EndMoveFriction;
            }
            else
            {
                EndState();
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

        if (!Character.Collider.Bottom)
            EndState();

    }

    public override void EndState()
    {
        base.EndState();
        Statistics.Friction = MoveFriction;
        Character.ChangeState(End);
    }
}
