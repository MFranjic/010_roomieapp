using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyProfileManager : MonoBehaviour
{
    public string userID;   // testing
    public bool testing = false;

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

    public GameObject budgetBlock;
    public GameObject typeBlock;
    public GameObject locationBlock;
    public GameObject rulesBlock;

    public GameObject interestsBlock;
    public GameObject languagesBlock;
    public GameObject myHobbiesBlock;
    public GameObject yourHobbiesBlock;
    public GameObject activitiesBlock;

    private bool loading = false;

    private void Start()
    {
        
    }

    /*public void LoadScene()
    {
        if (testing)
        {
            StartCoroutine(LoadData());
        }
    }*/

    IEnumerator LoadData()
    {
        loading = true;
        gameObject.GetComponent<DatabaseManager>().FetchStudentMain(userID);
        
        yield return new WaitWhile(() => loading == true);
        Debug.Log("Done1");

        loading = true;
        gameObject.GetComponent<DatabaseManager>().FetchStudentAlgo(userID);

        yield return new WaitWhile(() => loading == true);
        Debug.Log("Done2");
    }

    public void LoadStudentMainFromDatabase(StudentMain studentMain)
    {
        //Debug.Log(studentMain.Name);
        LoadSceneMainInfo(studentMain);
        loading = false;
    }

    public void LoadStudentAlgoFromDatabase(StudentAlgo studentAlgo)
    {
        //Debug.Log(studentMain.Name);
        LoadSceneAlgoInfo(studentAlgo);
        loading = false;
    }

    private void LoadSceneMainInfo(StudentMain student)
    {
        name.text = student.Name;
        surname.text = student.Surname;
        birthday.text = student.Birthday;
        gender.text = student.Gender;
        origin.text = student.Origin;
        residence.text = student.Residence;
        mobilityLocation.text = student.Destination;
        phone.text = student.Phone;
        email.text = userID;
        study.text = student.Faculty;
        work.text = student.Work;
        description.text = student.Description;
    }

    private void LoadSceneAlgoInfo(StudentAlgo student)
    {
        languages.text = student.Languages;
        pets.text = student.Pets;
        guests.text = student.Guests;
        smoking.text = student.Smoking;
    }
}
