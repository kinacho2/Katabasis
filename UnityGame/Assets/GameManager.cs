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


    
    public static GameManager Instance { get; protected set; }


    private void Awake()
    {
        if (!Instance)
        {
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
}
