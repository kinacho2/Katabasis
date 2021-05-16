using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollider : MonoBehaviour
{

    [SerializeField] BoxCollider2D MainCollider;
    [SerializeField] BoxCollider2D ThisCollider;

    [SerializeField] bool Horizontal;//no es top o bot
    [SerializeField] bool Opposite;//Izquierda y Abajo

    private void Awake()
    {
        ThisCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        Vector3 offset = MainCollider.offset * MainCollider.transform.localScale;
        Vector3 pos = MainCollider.transform.position;
        Vector3 size = MainCollider.size * MainCollider.transform.localScale;

        Vector2 localScale = new Vector2(MainCollider.transform.localScale.x, MainCollider.transform.localScale.y);

        ThisCollider.offset = Vector2.zero;

        if (Horizontal)
        {
            if (Opposite)
            {
                var aux = size;
                aux.y = 0;
                pos = pos - aux / 2f;
                ThisCollider.transform.position = pos + offset;

                var size2 = size;
                size2.y = size.y / 2f;
                size2.x = size.x / 10f;

                ThisCollider.size = size2;
            }
            else
            {
                var aux = size;
                aux.y = 0;
                pos = pos + aux / 2f;
                ThisCollider.transform.position = pos + offset;

                var size2 = size;
                size2.y = size.y / 2f;
                size2.x = size.x / 10f;

                ThisCollider.size = size2;
            }
        }
        else
        {
            if (Opposite)
            {
                var aux = size;
                aux.x = 0;
                pos = pos - aux / 2f;
                ThisCollider.transform.position = pos + offset;

                var size2 = size * localScale;
                size2.y = size.y / 5f;

                ThisCollider.size = size2;
            }
            else
            {
                var aux = size;
                aux.x = 0;
                pos = pos + aux / 2f;
                ThisCollider.transform.position = pos + offset;

                var size2 = size * localScale;
                size2.y = size.y / 5f;

                ThisCollider.size = size2;
            }
        }
    }

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
