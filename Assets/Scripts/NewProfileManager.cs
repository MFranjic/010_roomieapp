using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProfileManager : MonoBehaviour
{
    public GameObject blockContainer;

    private int objectFitterVar = 0;

    private void Start()
    {
        HideErrors();
    }

    public void SaveProfile()
    {
        bool hasErrors = CheckForErrors();
        if (!hasErrors)
        {
            
        }
    }

    private void HideErrors()
    {
        objectFitterVar = 0;

        for (int i = 0; i < blockContainer.transform.childCount; i++)
        {
            if (blockContainer.transform.GetChild(i).GetComponent<BlockScript>() != null)
            {
                blockContainer.transform.GetChild(i).GetComponent<BlockScript>().HideError();
            }
        }
        Vector2 delta = blockContainer.GetComponent<RectTransform>().sizeDelta;
        blockContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, delta.y + objectFitterVar);
    }

    private bool CheckForErrors()
    {
        objectFitterVar = 0;
        bool errorFound = false;

        for (int i = 0; i < blockContainer.transform.childCount; i++)
        {
            if (blockContainer.transform.GetChild(i).gameObject.activeSelf && blockContainer.transform.GetChild(i).GetComponent<BlockScript>() != null)
            {
                if (blockContainer.transform.GetChild(i).GetComponent<BlockScript>().CheckValidation())
                {
                    errorFound = true;
                }
            }
        }
        Vector2 delta = blockContainer.GetComponent<RectTransform>().sizeDelta;
        blockContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, delta.y + objectFitterVar);

        return errorFound;
    }

    public void ChangeSize(int difference)
    {
        objectFitterVar += difference;
    }
}
