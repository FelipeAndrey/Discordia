using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public Canvas Canvas;
    public string BargainDescription { get; set; }

    public void AddNewDescription()
    {
        RectTransform rectTransform = new RectTransform();
        TextMeshProUGUI Description = new TextMeshProUGUI();
        Description.text = BargainDescription;
    }
}
