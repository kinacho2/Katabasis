using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var prevent = FindObjectOfType<PreventInitialization>();
        if (!prevent)
            SceneManager.LoadScene("Init");
    }

    [SerializeField] int MaxLife = 3;
    
    public static GameManager Instance { get; protected set; }

    public int Lifes { get; protected set; }
    public int Deaths { get; protected set; }

    private void Awake()
    {
        if (!Instance)
        {
            Lifes = MaxLife;
            Deaths = 0;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this.gameObject);


    }

    private void Start()
    {
        SceneManager.LoadScene("Menu");
    }

    internal void InitHub()
    {
        SceneManager.LoadScene("Hub");
    }

    public void Damage(Character character)
    {
        Lifes--;
        if (Lifes <= 0)
        {
            character.Death();
        }
    }

    public void Death()
    {
        Deaths++;
        Lifes = MaxLife;
        SceneManager.LoadScene("Hub");
    }
}
