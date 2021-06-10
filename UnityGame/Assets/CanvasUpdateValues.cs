using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasUpdateValues : MonoBehaviour
{
    [SerializeField] Image[] Lifes;
    [SerializeField] TextMeshProUGUI Deaths;


    private void Update()
    {
        for(int i= 0; i< Lifes.Length; i++)
        {
            var color = Lifes[i].color;
            color.a = i < GameManager.Instance.Lifes?1:0;
            Lifes[i].color = color;
        }

        Deaths.text = ""+GameManager.Instance.Deaths;
    }

}
