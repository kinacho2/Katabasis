using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideText : MonoBehaviour
{
    [SerializeField] TextAsset Text;
    [SerializeField] TMPro.TextMeshProUGUI TextField;
    [SerializeField] RectTransform MovePanel;

    [SerializeField] float speed = 100;

    float LowSpeed;
    float MaxSpeed;

    [SerializeField] float heightRef;
    [SerializeField] float height;

    [SerializeField] float InitRef;
    [SerializeField] float EndRef;
    [SerializeField] RectTransform InitRefTransform;
    [SerializeField] RectTransform EndRefTransform;
    [SerializeField] int count;

    [SerializeField] public CharacterInput Joystick;


    private void Awake()
    {
        LowSpeed = speed;
        MaxSpeed = speed * 10;
        TextField.text = Text.text;

        InitRef = Mathf.Abs(InitRefTransform.offsetMax.y);
        EndRef = Mathf.Abs(EndRefTransform.offsetMax.y);
        string[] separator = { "\n" };
        string[] array = Text.text.Split(separator, System.StringSplitOptions.None);

        count = array.Length;

        height = heightRef * count;

        var offsetMax = MovePanel.offsetMax;
        var offsetMin = MovePanel.offsetMin;

        offsetMax.y = -InitRef;
        offsetMin.y = -InitRef - height;

        MovePanel.offsetMax = offsetMax;
        MovePanel.offsetMin = offsetMin;

        //EndRef = EndRef * count;
    }

    bool moving = true;
    private void FixedUpdate()
    {
        if (!moving) return;

        if (Joystick.inputReader.Jumping)
        {
            speed = MaxSpeed;
        }
        else
        {
            speed = LowSpeed;
        }

        if(MovePanel.offsetMin.y < EndRef)
        {
            var offsetMax = MovePanel.offsetMax;
            var offsetMin = MovePanel.offsetMin;

            offsetMin.y += Time.fixedDeltaTime*speed;
            offsetMax.y = offsetMin.y + height;

            MovePanel.offsetMax = offsetMax;
            MovePanel.offsetMin = offsetMin;
        }
        else
        {
            moving = false;
            GameManager.Instance.InitHub();
        }
    }

}
