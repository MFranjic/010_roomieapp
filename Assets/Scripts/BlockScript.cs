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

    public GameObject ManagerObject;

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
            if (ManagerObject.GetComponent<StudyWorkManager>().ValidateData(gameObject))
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
                ManagerObject.GetComponent<NewProfileManager>().ChangeSize(-errorHeight);
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
            ManagerObject.GetComponent<NewProfileManager>().ChangeSize(errorHeight);

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

    public string GetStringData()
    {
        string stringData = "";
        if (dataField.GetComponent<TMP_InputField>())                   // Text input fields
        {
            stringData = dataField.GetComponent<TMP_InputField>().text;
        }
        else if (dataField.GetComponent<Button>())                      // Date choosing field
        {
            stringData = dataField.GetComponent<DateValidation>().dateText.text;
        }
        return stringData;
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
                ManagerObject.GetComponent<StudyWorkManager>().InitializeStudy();
                dataAtValue = "Studying";
            }
            else if (intData == 1)
            {
                ManagerObject.GetComponent<StudyWorkManager>().InitializeWork();
                dataAtValue = "Working";
            }
            else if (intData == 2)
            {
                ManagerObject.GetComponent<StudyWorkManager>().InitializeBoth();
                dataAtValue = "Studying & working";
            }
        }
        return dataAtValue;
    }

    public string GetIntData()
    {
        int intData = 0;
        if (dataField.GetComponent<TMP_Dropdown>())                     // Dropdown fields
        {
            intData = dataField.GetComponent<TMP_Dropdown>().value - 1;
        }
        else                                                            // Study & work block
        {
            intData = ManagerObject.GetComponent<StudyWorkManager>().CheckStudyWorkBlock();
        }

        return intData.ToString();
    }

    public int GetDropdownSize()
    {
        return dataField.GetComponent<TMP_Dropdown>().options.Count - 1;
    }
}
