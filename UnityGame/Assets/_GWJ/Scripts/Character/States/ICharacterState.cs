using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState 
{

    void Update();

    void StateEnter(ICharacterState prevState);

    void StateExit();


}
