using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : GroundedState
{
    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        if (Character.Collider.Bottom)
            UpdateMove(deltaTime);
        else
            EndState();

    }
}
