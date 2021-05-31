using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixTextReference : MonoBehaviour
{
    private void Awake()
    {
        var b = GetComponentInParent<UITestBlock>();
        b.Title = GetComponentInChildren<Text>();
    }
}
