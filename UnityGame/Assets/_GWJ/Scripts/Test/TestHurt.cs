using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHurt : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Character>();
        if (character)
        {
            character.Hurt(1, transform.position, Vector2.zero);
        }
    }

}
