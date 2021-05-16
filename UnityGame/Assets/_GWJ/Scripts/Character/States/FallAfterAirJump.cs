using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAfterAirJump : AirState
{
    public override void CustomUpdate(float deltaTime)
    {
        UpdateMove(deltaTime);
        if (Character.Collider.Bottom)
            EndState();
    }
}
