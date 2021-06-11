using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] Spawn Spawn;

    public static SpawnPlayer Instance { get; protected set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RespawnPlayer(Character Character)
    {
        Character.Velocity = Vector3.zero;
        var pos = Character.transform.position;
        pos.x = Spawn.transform.position.x;
        pos.y = Spawn.transform.position.y;
        Character.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<Character>();
        if (character)
        {
            RespawnPlayer(character);
        }
    }

}
