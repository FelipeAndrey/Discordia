using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
