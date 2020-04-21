using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sliderValue : MonoBehaviour
{
    string currentValue = "0";

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = currentValue;
    }

    public void changeTextValue(Slider newValue)
    {
        if (newValue.value == 181)
            currentValue = "360";
        else
            currentValue = newValue.value.ToString();
    }
}
