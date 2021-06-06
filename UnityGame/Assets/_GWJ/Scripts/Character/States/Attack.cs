using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: GroundedState
{
    [SerializeField] AnimatorEvent AnimatorEvent;

    [SerializeField] SubAttack[] List;

    [SerializeField] int index = 0;

    [SerializeField] float StepCooldown = .6f;

    bool flag = false;

    float timer = 0;

    public override void StateEnter(IState prevState)
    {
        AnimatorEvent.SetCallback(EndState);
        
        Character.ChangeState(List[index]);
        
        Character.Velocity = Vector3.zero;
        index = (index + 1) % List.Length;
        timer = 0;

        //base.StateEnter(prevState);
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

    }

    public override void EndState()
    {
        AnimatorEvent.SetCallback(null);//TODO TENE CUIDADO CON ESTO!!!
        base.EndState();
        flag = true;
    }

   

    private void Update()
    {
        if (flag)
        {
            timer += Time.deltaTime;
            if (timer > StepCooldown)
            {
                index = 0;
                flag = false;
                
            }
        }
    }

    public override bool Damage(Vector3 position, Vector2 Retroceso)
    {
        return false;
    }

}
