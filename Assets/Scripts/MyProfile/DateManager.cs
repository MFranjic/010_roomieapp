using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DateManager : MonoBehaviour
{
    public GameObject selectedButton;
    public GameObject panelDatePicker;
    
    public void SetDateOnSelected(string date)
    {
        selectedButton.transform.GetChild(0).GetComponent<Text>().text = date;
        panelDatePicker.SetActive(false);
    }

    public void CancelDateSelection()
    {
        panelDatePicker.SetActive(false);
    }

    public void ActivateDatePicker()
    {
        selectedButton = EventSystem.current.currentSelectedGameObject.gameObject;
        panelDatePicker.SetActive(true);
    }
}
