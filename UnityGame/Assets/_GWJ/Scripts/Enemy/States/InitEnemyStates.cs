using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemyStates : MonoBehaviour
{
    [SerializeField] Enemy Enemy;
    [SerializeField] EnemyState[] States;

    private void Awake()
    {
        States = GetComponentsInChildren<EnemyState>();
        foreach (var state in States)
        {
            state.Init(Enemy);
        }
    }
}
