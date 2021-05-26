using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHurt : CharacterState
{
    [SerializeField] Vector2 retroceso;


    public override void StateEnter(CharacterState prevState)
    {
        prevState.EndState();
        base.StateEnter(prevState);

        Vector2 dir = Character.Direction;
        Character.Velocity = (-dir * retroceso.x + new Vector2(0, 1) * retroceso.y);

    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);
        UpdateMove(deltaTime);

        if (Character.Collider.Bottom)
            EndState();
    }

}
