using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState 
{

    void CustomUpdate();

    void StateEnter(ICharacterState prevState);

    void StateExit();


}
