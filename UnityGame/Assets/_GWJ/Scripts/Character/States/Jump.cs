using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AirState
{
    [SerializeField] float V0;
    [SerializeField] bool jumping = false;
    [SerializeField] float distance = 0;

    private void Awake()
    {
        //V0 =- Mathf.Sqrt(2 * Statistics.JumpHeight * Statistics.Acceleration);
    }

    bool semaphore;

    public override void StateEnter(IState prevState)
    {
        V0 = Mathf.Sqrt(2 * Statistics.JumpAcceleration * Character.Statistics.Gravity);

        base.StateEnter(prevState);

        distance = 0;
    }

    public override void CustomUpdate(float deltaTime)
    {
        if (Character.Joystick.inputReader.OnJump)
        {
            Character.ChangeState(Jump);
            //semaphore = true;
            return;

        }
        if (Character.Joystick.inputReader.OnAttack)
        {
            Character.ChangeState(Attack);
            return;
            //semaphore = true;
        }
        if (!semaphore)
        {
            if (Character.Joystick.inputReader.Jumping)
            {

                if (!jumping)
                {
                    jumping = true;
                    Character.Velocity += new Vector3(0, V0, 0);
                    V0 = 0;
                }
                else
                {
                    Character.Velocity += new Vector3(0, Character.Statistics.Gravity, 0)
                                            * deltaTime;
                }


            }
            if (!Character.Joystick.inputReader.Jumping || distance > Statistics.JumpHeight)
            {
                jumping = false;
            }

            UpdateMove(deltaTime);

            distance += deltaTime * Character.Velocity.y;

            if (Character.Velocity.y <= 0.1f || Character.Collider.Top)
            {
                //Debug.LogError("End Jump por speed");
                Character.Velocity.y = 1;
                EndState();
            }
        }
        semaphore = false;
    }

    public override void UpdateMove(float deltaTime)
    {
        base.UpdateMove(deltaTime);
    }

    public override void EndState()
    {
        //Vector2 velocity = Character.Rigidbody.velocity;
        //velocity.y = 0;
        //if(setVelocity0)
           // Character.Rigidbody.velocity = velocity;

        base.EndState();
        jumping = false;
        //Character.Rigidbody.gravityScale = 1;
        //Character.ChangeState(End);
    }
}
