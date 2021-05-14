using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppedDetector : MonoBehaviour
{
    [SerializeField] Character Character;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character.Topped = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Character.Topped = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character.Topped = false;
    }
}
