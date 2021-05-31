using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoAttack: EnemyState
{
    [SerializeField] Vector3 AttackForce;
    public override void StateEnter(IState prevState)
    {
        base.StateEnter(prevState);
        if (Enemy.Collider.Grounded)
        {
            Enemy.Direction = 
                new Vector3(
                    Mathf.Sign(Enemy.Direction.x)  *AttackForce.x
                    , 
                    AttackForce.y);
        }
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        if(Enemy.Direction.y < 0)
        {
            EndState();
        }
             
        
    }

}
