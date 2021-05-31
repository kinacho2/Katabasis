using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoHurt : EnemyState
{
    [SerializeField] Vector2 retroceso;
    public override void StateEnter(IState prevState)
    {
        base.StateEnter(prevState);
        Enemy.Direction = Vector3.zero;
    }
    public override bool Damage(Vector3 position)
    {
        Enemy.Direction = new Vector3(
            Mathf.Sign( transform.position.x - position.x ) * retroceso.x,
            retroceso.y, 0

            );

        return true;

    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);
        if (Enemy.Direction.y < 0)
            EndState();
    }

}
