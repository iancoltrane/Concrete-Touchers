using System;
using UnityEngine;
using UnityEngine.UI;

public class IntegerDisplay : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private int startValue;
    [SerializeField] private string contentOutline = "Score - {0}";

    private void Awake()
    {
        DisplayInteger(startValue);
    }

    public void DisplayInteger(int value)
    {
        text.text = string.Format(contentOutline, value.ToString());
    }
}