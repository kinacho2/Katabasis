using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    [SerializeField] Character Character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            
            enemy.Hurt(1,transform.position, Character.State.Statistics.Retroceso);
        }

    }
}
