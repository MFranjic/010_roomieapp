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
        bool validated = false;
        if (dataField.GetComponent<TMP_InputField>())                   // Text input fields
        {
            if (!string.IsNullOrEmpty(dataField.GetComponent<TMP_InputField>().text))
            {
                validated = true;
            }
        }
        else if (dataField.GetComponent<TMP_Dropdown>())                // Dropdown fields
        {
            if (!string.IsNullOrEmpty(dataField.GetComponent<TMP_Dropdown>().options[dataField.GetComponent<TMP_Dropdown>().value].text))
            {
                validated = true;
            }
        }
        else if (dataField.GetComponent<Button>())                      // Date choosing field
        {
            if (dataField.GetComponent<DateValidation>().isValidated())
            {
                validated = true;
            }
        }
        else                                                            // Study & work block
        {
            if (GameObject.Find("SceneManager").GetComponent<StudyWorkManager>().ValidateData(gameObject))
            {
                validated = true;
            }
        }

        if (validated)
        {
            HideError();
        }
        else
        {
            DisplayError();
        }
        return !errorUp;
    }

    public void HideError()
    {
        if (errorUp)
        {
            Vector2 delta = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(delta.x, delta.y - errorHeight);
            
            if (gameObject.activeSelf)
            {
                GameObject.Find("SceneManager").GetComponent<NewProfileManager>().ChangeSize(-errorHeight);
            }

            errorText.gameObject.SetActive(false);
            errorUp = false;
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
            errorUp = true;
        }        
    }

    public void SetStringData(string stringData)
    {
        if (dataField.GetComponent<TMP_InputField>())                   // Text input fields
        {
            dataField.GetComponent<TMP_InputField>().text = stringData;
        }
        else if (dataField.GetComponent<Button>())                      // Date choosing field
        {
            dataField.GetComponent<DateValidation>().dateText.text = stringData;
        }

    }

    public string SetIntData(int intData)
    {
        string dataAtValue = "";
        if (dataField.GetComponent<TMP_Dropdown>())                     // Dropdown fields
        {
            dataField.GetComponent<TMP_Dropdown>().value = intData + 1;
            dataAtValue = dataField.GetComponent<TMP_Dropdown>().options[intData + 1].text;
        }      
        else                                                            // Study & work block
        {
            if (intData == 0)
            {
                GameObject.Find("SceneManager").GetComponent<StudyWorkManager>().activateStudy();
            }
            else if (intData == 1)
            {
                GameObject.Find("SceneManager").GetComponent<StudyWorkManager>().activateWork();
            }
            else if (intData == 2)
            {
                GameObject.Find("SceneManager").GetComponent<StudyWorkManager>().activateBoth();
            }
        }
        return dataAtValue;
    }

    public int GetDropdownSize()
    {
        return dataField.GetComponent<TMP_Dropdown>().options.Count - 1;
    }
}
