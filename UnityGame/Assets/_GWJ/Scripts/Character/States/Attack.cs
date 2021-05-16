using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: GroundedState
{
    [SerializeField] AnimatorEvent AnimatorEvent;
    public override void StateEnter(CharacterState prevState)
    {
        Character.Velocity = Vector3.zero;
        AnimatorEvent.SetCallback(EndState);
        base.StateEnter(prevState);
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

    }

    public override void EndState()
    {
        AnimatorEvent.SetCallback(null);//TODO TENE CUIDADO CON ESTO!!!
        base.EndState();
    }

    public override void UpdateMove(float deltaTime)
    {
        Character.Velocity += new Vector3(0, Character.Statistics.Gravity, 0)
                                        * deltaTime;
        base.UpdateMove(deltaTime);
    }
}
