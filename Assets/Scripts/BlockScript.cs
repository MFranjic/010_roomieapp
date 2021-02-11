using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockScript : MonoBehaviour
{
    public TMP_Text errorText;
    public string errorMessage;

    public int height;
    public int errorHeight;

    public GameObject dataField;

    private string text;
    private bool errorUp = true;

    private void Start()
    {
        errorText.text = errorMessage;
        
    }

    public bool CheckValidation()
    {
        if (dataField.GetComponent<TMP_InputField>())
        {
            text = dataField.GetComponent<TMP_InputField>().text;
        }
        else if (dataField.GetComponent<TMP_Dropdown>())
        {
            text = dataField.GetComponent<TMP_Dropdown>().options[dataField.GetComponent<TMP_Dropdown>().value].text;
        }

        if (!string.IsNullOrEmpty(text))
        {
            //Debug.Log(text);
            HideError();
            errorUp = false;
        }
        else
        {
            DisplayError();
            errorUp = true;
        }
        return !errorUp;
    }

    private void HideError()
    {
        if (errorUp)
        {
            Vector2 delta = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(delta.x, delta.y - errorHeight);
            GameObject.Find("SceneManager").GetComponent<NewProfileManager>().ChangeSize(-errorHeight);

            errorText.gameObject.SetActive(false);
        }
    }

    private void DisplayError()
    {
        if (!errorUp)
        {
            Vector2 delta = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(delta.x, delta.y + errorHeight);
            GameObject.Find("SceneManager").GetComponent<NewProfileManager>().ChangeSize(errorHeight);

            errorText.gameObject.SetActive(true);
        }        
    }
}
