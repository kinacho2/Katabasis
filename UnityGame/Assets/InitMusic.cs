using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMusic : MonoBehaviour
{
    [SerializeField] AudioClip MenuMusic;
    void Start()
    {
        if (SoundManager.Instance.CurrentMusic.clip != MenuMusic)
            SoundManager.Instance.ChangeMusic(MenuMusic, .1f, true, false);
    }

}
