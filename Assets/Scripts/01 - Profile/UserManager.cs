using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserManager : MonoBehaviour
{
    public string userID;   // testing

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

    public GameObject EditUserGrid;
    public GameObject RoomGrid;
    public GameObject PersonGrid;

    private bool loading = false;

    private StudentAlgo studentAlgo;
    private StudentMain studentMain;

    public void LoadScene()
    {
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData()
    {
        loading = true;
        gameObject.GetComponent<DatabaseManager>().FetchStudentMain(userID);
        
        yield return new WaitWhile(() => loading == true);

        loading = true;
        //Debug.Log("Fetching algo...");
        gameObject.GetComponent<DatabaseManager>().FetchStudentAlgo(userID);

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
       
        EditUserGrid.GetComponent<EditMainData>().FillInMainData(student);
    }

    private void LoadSceneAlgoInfo(StudentAlgo student)
    {       
        studentAlgo = student;      

        languages.text = student.Languages;

        student.ParsePrio();
        gameObject.GetComponent<UserNavigation>().NavigateMain("ROOM");
        RoomGrid.GetComponent<GridScript>().LoadAlgoData(student);
        gameObject.GetComponent<UserNavigation>().NavigateMain("PERSON");
        PersonGrid.GetComponent<GridScript>().LoadAlgoData(student);
        gameObject.GetComponent<UserNavigation>().NavigateMain("PROFILE");

        EditUserGrid.SetActive(true);
        EditUserGrid.GetComponent<EditMainData>().FillInAlgoData(student);
        EditUserGrid.SetActive(false);
    }

    public void SetSavingCompleted()
    {
        EditUserGrid.GetComponent<EditMainData>().SavingDone();
    }
}
