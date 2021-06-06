using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, IState
{

    protected IState PrevState;
    protected Enemy Enemy;

    [SerializeField] EnemyState End;
    [SerializeField] EnemyState Hurt;
    public virtual void Init(Enemy enemy)
    {
        Enemy = enemy;
    }

    public virtual void CustomUpdate(float deltaTime)
    {
        var vel = Enemy.Direction;

        if (!Enemy.Collider.Grounded)
        {
            vel += new Vector3(0, -Enemy.Gravity, 0)
                * deltaTime;

            vel.y = Mathf.Clamp(vel.y, -2, 2);
        }
        else
        {
            vel.y = Mathf.Clamp(vel.y, 0, 2);
        }
        Enemy.Direction = vel;
    }

    public virtual void EndState()
    {
        Enemy.ChangeState(End);
    }

    public virtual void StateEnter(IState prevState)
    {
        PrevState = prevState;
        if (prevState != null)
            prevState.StateExit();

    }


    public virtual void StateExit()
    {
    }


    public virtual void Move(float deltaTime)
    {
        Enemy.Rigidbody.MovePosition(transform.position
           + Enemy.Direction * Enemy.Speed * Time.fixedDeltaTime);

    }

    public virtual bool Damage(Vector3 position, Vector2 Retroceso)
    {
        Enemy.ChangeState(Hurt);
        return Hurt.Damage(position, Retroceso);
    }

}
