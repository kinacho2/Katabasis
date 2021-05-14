using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedDetector : MonoBehaviour
{
    [SerializeField] Character Character;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character.Grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Character.Grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character.Grounded = false;
    }
}
