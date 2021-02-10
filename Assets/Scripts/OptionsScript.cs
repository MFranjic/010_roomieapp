using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public int sliderEnabledHeight;
    public int sliderDisabledHeight;
    
    public void EnableOptions()
    {
        RectTransform slider = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderEnabledHeight);       
        Vector3 position = new Vector3(0, 20, 0);

        slider.sizeDelta = sizeDelta;
        slider.anchoredPosition = position;

        transform.GetChild(1).gameObject.GetComponent<Slider>().interactable = true;
    }

    public void DisableOptions()
    {
        RectTransform slider = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderDisabledHeight);
        Vector3 position = new Vector3(0, 10, 0);

        slider.sizeDelta = sizeDelta;
        slider.anchoredPosition = position;

        transform.GetChild(1).gameObject.GetComponent<Slider>().interactable = false;
    }
}
