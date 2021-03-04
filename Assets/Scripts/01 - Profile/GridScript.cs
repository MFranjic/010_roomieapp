using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    private bool saving = false;

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
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().RollBackChanges();
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().DisableOptions();
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().RefreshEdit();
        }
    }

    public void SaveChanges()
    {
        StudentAlgo studentAlgo = GameObject.Find("SceneManager").GetComponent<UserManager>().FetchStudentAlgo();
 
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            studentAlgo = gameObject.transform.GetChild(i).GetComponent<OptionsScript>().SetAlgoData(studentAlgo);
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().DisableOptions();
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().RefreshEdit();
        }

        studentAlgo.SetPrioDataString();
        StartCoroutine(SaveData(studentAlgo));
    }

    IEnumerator SaveData(StudentAlgo studentAlgo)
    {
        saving = true;
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().AddStudentAlgo(studentAlgo);

        yield return new WaitWhile(() => saving == true);
    }

    public void LoadAlgoData(StudentAlgo student)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().LoadAlgoData(student);
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<OptionsScript>().CreateOptions();
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
