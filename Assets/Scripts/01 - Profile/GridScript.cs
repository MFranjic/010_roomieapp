using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public void ActivateEdit()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().EnableOptions();
        }
    }

    public void CancelEdit()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().DisableOptions();
        }
    }

    public void SaveChanges()
    {
        //StudentAlgo newAlgoData = new StudentAlgo();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().DisableOptions();
        }
    }

    public void RandomSelection()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().CreateRandomOptions();
        }
    }
}
