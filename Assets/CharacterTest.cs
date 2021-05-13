using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterTest : MonoBehaviour
{
    [SerializeField] CharacterInput Joystick;
    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] bool onair = false;
    [SerializeField] float Force = 100;

    [SerializeField] float velocity = 100;

    private void Update()
    {
        Joystick.inputReader.ButtonInput();
    }

    private void FixedUpdate()
    {
        
        if (Joystick.inputReader.OnJump)
        {
            Rigidbody.AddForce(new Vector2(0, Force));
            Debug.Log("Jump!!!!");
        }

        Vector2 move = Joystick.inputReader.Stick * velocity * Time.fixedDeltaTime;
        move.y = 0;
        if (move.magnitude > 0.1f)
        {
            Vector2 pos = transform.position;
            transform.position = transform.position + new Vector3(move.x,0,0);
        }

    }

}
