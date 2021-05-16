using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollider : MonoBehaviour
{

    protected Action<bool> Collision;

    public void SetCollisionAction(Action<bool> action)
    {
        Collision = action;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Collision?.Invoke(false);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Collision?.Invoke(true);

    }
}
