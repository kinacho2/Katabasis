using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : GroundedState
{



    [SerializeField] float StuntTime = 1;
    [SerializeField] Vector2 retroceso;
    
    public override void StateEnter(IState prevState)
    {
        prevState.EndState();
        base.StateEnter(prevState);
        timer = 0;

        Vector2 dir = Character.Direction;
        Character.Velocity = (-dir * retroceso.x + new Vector2(0,1) * retroceso.y);

    }

    float timer = 0;

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);
        timer += deltaTime;

        if (timer > StuntTime)
            EndState();
    }

}
