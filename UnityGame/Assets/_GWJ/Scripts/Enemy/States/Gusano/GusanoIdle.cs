using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoIdle : EnemyState
{

    public override void StateEnter(IState prevState)
    {
        base.StateEnter(prevState);
        Enemy.Direction.x = Mathf.Sign(Enemy.Direction.x);
    }

    public override void CustomUpdate(float deltaTime)
    {
        if (!Enemy.Collider.Grounded) return;

        base.CustomUpdate(deltaTime);
        
        {
            if (!Enemy.Collider.Left || Enemy.Collider.Top)
            {
                
                Enemy.Direction = new Vector3(1, 0, 0);
            }

            if (!Enemy.Collider.Right || Enemy.Collider.Bottom)
            {
                Enemy.Direction = new Vector3(-1, 0, 0);

            }
        }
        
    }

    public override void Move(float deltaTime)
    {
        if (Enemy.Collider.Grounded)
            base.Move(deltaTime);
    }
}
