using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProfileManager : MonoBehaviour
{
    public GameObject blockContainer;

    private int objectFitterVar = 0;

    public void SaveProfile()
    {
        CheckForErrors();
    }

    private bool CheckForErrors()
    {
        objectFitterVar = 0;
        bool errorFound = false;

        for (int i = 0; i < blockContainer.transform.childCount; i++)
        {
            if (blockContainer.transform.GetChild(i).GetComponent<BlockScript>() != null)
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
