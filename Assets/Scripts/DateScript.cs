using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DateScript : MonoBehaviour
{
    public int startYear;
    public int endYear;

    public string testText;

    private void Start()
    {
        transform.GetChild(4).gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = "" });

        for (int i = 0; i < endYear - startYear; i++)
        transform.GetChild(4).gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData() { text = (startYear + i).ToString() });

        SetQuestionText(testText);
    }

    public void SetQuestionText(string text)
    {
        transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = text;
    }
    
    public void SaveDate()
    {
        TMP_Dropdown yearDD = transform.GetChild(4).gameObject.GetComponent<TMP_Dropdown>();

        int day = transform.GetChild(2).gameObject.GetComponent<TMP_Dropdown>().value;
        int month = transform.GetChild(3).gameObject.GetComponent<TMP_Dropdown>().value;
        string year = yearDD.options[yearDD.value].text;

        string date = day + "/" + month + "/" + year;
        GameObject.Find("SceneManager").GetComponent<DateManager>().SetDateOnSelected(date);
    }
}
