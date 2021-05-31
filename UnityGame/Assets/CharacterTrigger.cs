using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    [SerializeField] Transform Flip;
    [SerializeField] Enemy Enemy;
    [SerializeField] EnemyState Idle;
    [SerializeField] EnemyState Attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Character>();
        if (character)
        {
            
            Enemy.ChangeState(Attack);
        }


    }

    private void Update()
    {
        if (Enemy.Direction.x > 0)
        {
            Flip.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            Flip.transform.localScale = new Vector3(1, 1, 1);

        }
    }

}
