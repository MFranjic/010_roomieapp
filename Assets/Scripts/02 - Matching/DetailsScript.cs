using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailsScript : MonoBehaviour
{
    public TMP_Text name;
    public TMP_Text surname;
    public TMP_Text birthday;
    public TMP_Text gender;
    public TMP_Text origin;
    public TMP_Text residence;
    public TMP_Text mobilityLocation;
    public TMP_Text mobilityTime;
    public TMP_Text phone;
    public TMP_Text email;
    public TMP_Text study;
    public TMP_Text work;
    public TMP_Text languages;
    public TMP_Text pets;
    public TMP_Text smoking;
    public TMP_Text guests;
    public TMP_Text description;

    private bool loading = false;
    private string userID;

    private StudentAlgo studentAlgo;
    private StudentMain studentMain;

    public void SendPin()
    {
        GameObject.Find("SceneManager").GetComponent<MatchingNavigation>().SendPin(userID);
    }

    public void SendRequest()
    {
        GameObject.Find("SceneManager").GetComponent<MatchingNavigation>().SendRequest(userID);
    }

    public void LoadScene(string userID)
    {
        this.userID = userID;
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        loading = true;
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().FetchDetailsMain(userID);

        yield return new WaitWhile(() => loading == true);

        loading = true;
        //Debug.Log("Fetching algo...");
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().FetchDetailsAlgo(userID);

        yield return new WaitWhile(() => loading == true);
    }

    public void LoadStudentMainFromDatabase(StudentMain studentMain)
    {
        LoadSceneMainInfo(studentMain);
        //Debug.Log("Loaded main.");
        loading = false;
    }

    public void LoadStudentAlgoFromDatabase(StudentAlgo studentAlgo)
    {
        LoadSceneAlgoInfo(studentAlgo);
        loading = false;
    }

    public StudentAlgo FetchStudentAlgo()
    {
        return studentAlgo;
    }

    public StudentMain FetchStudentMain()
    {
        return studentMain;
    }

    private void LoadSceneMainInfo(StudentMain student)
    {
        studentMain = student;

        name.text = student.Name;
        surname.text = student.Surname;
        birthday.text = student.Birthday;
        phone.text = student.Phone;
        email.text = student.GetEmail();
        work.text = student.Work;
        description.text = student.Description;
    }

    private void LoadSceneAlgoInfo(StudentAlgo student)
    {
        studentAlgo = student;

        languages.text = student.Languages;

        student.ParsePrio();
    }
}
