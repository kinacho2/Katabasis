using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoFall : EnemyState
{

    public override void StateEnter(IState prevState)
    {
        base.StateEnter(prevState);
        Enemy.Speed = 1;
    }

    public override void CustomUpdate(float deltaTime)
    {
        if (Enemy.Collider.Grounded) 
        {
            EndState();
            return; 
        }

        base.CustomUpdate(deltaTime);
        
        
    }

}
