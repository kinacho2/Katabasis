using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] Spawners;
    [SerializeField] Enemy Prefab;

    public List<Enemy> Enemies;

    private void Start()
    {
        int count = Mathf.Clamp(GameManager.Instance.Dungeons * 4 + 7, 7, 28);
        int j = 4;
        Enemies = new List<Enemy>();
        for (int i=0; i<count; i++)
        {
            var tr = Spawners[(i * j + i) % Spawners.Length].transform;
            var enemy = Instantiate<Enemy>(Prefab, tr.position, tr.rotation);
            Enemies.Add(enemy);
        }

    }


    private void Update()
    {
        List<Enemy> torem = new List<Enemy>();
        foreach(var e in Enemies)
        {
            if (!e)
            {
                torem.Add(e);
            }
        }
        foreach(var e in torem)
        {
            Enemies.Remove(e);
        }
        if (Enemies.Count == 0)
        {
            GameManager.Instance.EndDungeon();
            Destroy(gameObject);
        }

    }
}
