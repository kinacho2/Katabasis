using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : CharacterState
{
    public override void CustomUpdate(float deltaTime)
    {
        if (Character.Joystick.inputReader.OnJump)
            Character.ChangeState(Jump);
        if (Character.Joystick.inputReader.OnAttack)
            Character.ChangeState(Attack);

    }

    public override void DoMove(float deltaTime)
    {
        float deltaSpeed = Character.Joystick.inputReader.Stick.x * Statistics.Acceleration * deltaTime;


        Vector2 velocity = Character.Rigidbody.velocity + new Vector2(deltaSpeed, 0);

        velocity.x = Mathf.Clamp(velocity.x, -Statistics.Speed.x, Statistics.Speed.x);

        velocity.x = Mathf.Sign(velocity.x) * Mathf.Max(Mathf.Abs(Character.Rigidbody.velocity.x), Mathf.Abs(velocity.x));

        Character.Rigidbody.velocity = velocity;
    }
}
