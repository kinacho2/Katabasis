using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestBlock : MonoBehaviour
{
    [SerializeField] public Text Title;
    [SerializeField] InputField Text;

    public void SetValue(float value)
    {
        Text.text = "" + value;
    }

    public void UpdateValue(ref float value)
    {
        value = GetValue();
    }

    public float GetValue()
    {
        string text = Text.text;
        
        float value = float.Parse(text);

        return value;
    }

    public void SetText(string value)
    {
        Title.text = value;
    }

}
