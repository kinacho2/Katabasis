using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState : MonoBehaviour, IState
{
    protected Character Character;

    [SerializeField] protected IState PrevState;

    [SerializeField] string AnimatorTrigger;

    [SerializeField] protected CharacterState End;
    [SerializeField] protected CharacterState Move;
    [SerializeField] protected CharacterState Jump;
    [SerializeField] protected CharacterState Roll;
    [SerializeField] protected CharacterState Attack;

    [SerializeField] protected CharacterState Hurt;

    [SerializeField] public Statistics Statistics;

    public virtual void Init(Character character)
    {
        Character = character;
    }

    public virtual void CustomUpdate(float deltaTime)
    {
        if (Character.Joystick.inputReader.OnJump)
            Character.ChangeState(Jump);
        if (Character.Joystick.inputReader.OnAttack)
            Character.ChangeState(Attack);
        if (Character.Joystick.inputReader.OnRoll)
            Character.ChangeState(Roll);
        if (Mathf.Abs(Character.Joystick.inputReader.Stick.x) > .1f)
            Character.ChangeState(Move);
    }

    public virtual void StateEnter(IState prevState)
    {
        PrevState = prevState;
        if (prevState != null)
            prevState.StateExit();
        Character.Animator.SetTrigger(AnimatorTrigger);
        

    }

    public virtual void StateExit()
    {

    }

    public virtual void EndState()
    {
        Character.ChangeState(End);
    }

    public virtual void UpdateMove(float deltaTime)
    {
        //Debug.LogError(Character.Velocity + " Clamping to " + Statistics.Speed.y);

        var vel = Character.Velocity;

        vel += new Vector3(Statistics.Acceleration* Character.Joystick.inputReader.Stick.x
            , 0, 0)
            * deltaTime;

        vel+= new Vector3(0, -Character.Statistics.Gravity, 0)
            * deltaTime;

        if(Mathf.Abs(vel.x) > 0.1f)
        {
            float x = vel.x;
            vel.x += Mathf.Sign(-vel.x) * Statistics.Friction*deltaTime;

            if(Vector3.Dot(vel, transform.right) > 0 && Character.Collider.Right)
            {
                vel.x = 0;
            }
            if (Vector3.Dot(vel, transform.right) < 0 && Character.Collider.Left)
            {
                vel.x = 0;
            }

            if (Mathf.Sign(vel.x)!= Mathf.Sign(x))
                vel.x = 0;
        }
        else
        {
            vel.x = 0;
        }
        

        vel.x = Mathf.Clamp(vel.x, -Character.Statistics.Speed.x, Character.Statistics.Speed.x);
        vel.y = Mathf.Clamp(vel.y, -Statistics.Speed.y, Statistics.Speed.y);

        Character.Velocity = vel;
    }

    public virtual bool Damage(Vector3 position, Vector2 Retroceso)
    {
        Character.Direction = new Vector2(
            
            Mathf.Sign(position.x - Character.transform.position.x)
            
            , 0);
        Character.ChangeState(Hurt);
        return true;
    }

}
