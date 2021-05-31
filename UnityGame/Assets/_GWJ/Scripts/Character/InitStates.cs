using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStates : MonoBehaviour
{
    [SerializeField] Character Character;
    [SerializeField] CharacterState[] States;

    private void Awake()
    {
        States = GetComponentsInChildren<CharacterState>();
        foreach(var state in States)
        {
            state.Init(Character);
        }
    }

}
