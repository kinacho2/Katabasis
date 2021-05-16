using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    Action Callback;


    public void SetCallback(Action a)
    {
        Callback = a;
    }

    public void Execute()
    {
        Callback?.Invoke();
    }
}
