using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Stats Stats;

    public virtual bool Hurt(float value, Vector3 position, Vector2 Retroceso)
    {
        Stats.Life -= value;
        return true;
    }
}
