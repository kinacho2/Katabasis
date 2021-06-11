using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : GroundedState
{
    [SerializeField] float timeDead = 5;
    float timer = 0;

    bool flag = false;


    public override void CustomUpdate(float deltaTime)
    {
        timer += deltaTime;
        if (timer > timeDead && !flag)
        {
            flag = true;
            GameManager.Instance.Death();
        }
    }

    public override void StateEnter(IState prevState)
    {
        Character.Velocity = Vector3.zero;
        base.StateEnter(prevState);
    }

    public override void UpdateMove(float deltaTime)
    {
        base.UpdateMove(deltaTime);
    }
}
