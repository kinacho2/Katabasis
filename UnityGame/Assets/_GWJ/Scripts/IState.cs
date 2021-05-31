using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void StateEnter(IState prevState);
    void StateExit();
    void EndState();
    void CustomUpdate(float deltaTime);
    bool Damage(Vector3 position);
}
