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

}
