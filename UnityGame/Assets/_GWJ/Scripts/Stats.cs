using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float MaxLife;
    public float life;

    private void Awake()
    {
        life = MaxLife;
    }

    public float Life 
    { 
        get 
        {
            return life;
        }
        set
        {
            life = value;
            life = Mathf.Max(0, Mathf.Min(life, MaxLife));
        }
    }

    

}
