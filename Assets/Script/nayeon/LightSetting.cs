using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSetting : MonoBehaviour
{
    public Image brightnessPanel;
    public Slider brightnessSlider;
    public void SetBrightness(float brightness)
    {
        Color color = brightnessPanel.color;
        color.a = brightness;
        brightnessPanel.color = color;
    }

    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    
    void Update()
    {
        
    }
}
