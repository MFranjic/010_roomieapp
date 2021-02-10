using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

        setQuestionText(testText);
    }

    public void setQuestionText(string text)
    {
        transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = text;
    }
}
