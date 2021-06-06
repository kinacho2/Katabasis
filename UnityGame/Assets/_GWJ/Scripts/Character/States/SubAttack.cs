using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttack : GroundedState
{
    public override void UpdateMove(float deltaTime)
    {
        Character.Velocity += new Vector3(0, Character.Statistics.Gravity, 0)
                                        * deltaTime;
        base.UpdateMove(deltaTime);
    }

    public override bool Damage(Vector3 position, Vector2 Retroceso)
    {
        return false;
    }
}
