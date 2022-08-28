using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScripts : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            sliderValue.text = v.ToString("0");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
