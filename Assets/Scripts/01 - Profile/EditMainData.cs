using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMainData : MonoBehaviour
{
    public GameObject nameBlock;

    public GameObject surnameBlock;

    public GameObject genderBlock;

    public GameObject birthdayBlock;

    public GameObject originBlock;

    public GameObject homeBlock;

    public GameObject destinationBlock;

    public GameObject phoneNumberBlock;

    public GameObject whatYouDoBlock;

    public GameObject studyBlock;

    public GameObject workBlock;

    public GameObject languagesBlock;

    public GameObject petsBlock;

    public GameObject smokingBlock;

    public GameObject guestsBlock;

    private GameObject ManagerObject;

    private StudentAlgo oldStudentAlgo;
    private StudentMain oldStudentMain;

    private StudentQuick studentQuick;
    private bool saving;

    public void SavingDone()
    {
        saving = false;
        Debug.Log("Saved.");
    }

    public void SaveMainDataChanges()
    {
        string name = nameBlock.GetComponent<BlockScript>().GetStringData();
        string surname = surnameBlock.GetComponent<BlockScript>().GetStringData();
        string birthday = birthdayBlock.GetComponent<BlockScript>().GetStringData();
        string phone = phoneNumberBlock.GetComponent<BlockScript>().GetStringData();
        string work = workBlock.GetComponent<BlockScript>().GetStringData();

        string gender = genderBlock.GetComponent<BlockScript>().GetIntData();
        string origin = originBlock.GetComponent<BlockScript>().GetIntData();
        string home = homeBlock.GetComponent<BlockScript>().GetIntData();
        string destination = destinationBlock.GetComponent<BlockScript>().GetIntData();
        string goal = whatYouDoBlock.GetComponent<BlockScript>().GetIntData();
        string study = studyBlock.GetComponent<BlockScript>().GetIntData();

        string pets = petsBlock.GetComponent<BlockScript>().GetIntData();
        string smoking = smokingBlock.GetComponent<BlockScript>().GetIntData();
        string guests = guestsBlock.GetComponent<BlockScript>().GetIntData();
        string languages = languagesBlock.GetComponent<OptionsScript>().GetStringData();

        oldStudentMain.ChangeStudentMain(name, surname, gender, birthday, origin, home, destination, phone, goal, study, work);
        studentQuick = new StudentQuick(name, oldStudentMain.GetEmail(), home, GetAge(birthday), gender);
        oldStudentAlgo.ChangeStudentAlgo(languages, pets, smoking, guests);

        StartCoroutine(SaveData());      
    }

    IEnumerator SaveData()
    {
        saving = true;
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().ChangeStudentMain(oldStudentMain);
        yield return new WaitWhile(() => saving == true);
        

        saving = true;
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().ChangeStudentAlgo(oldStudentAlgo);
        yield return new WaitWhile(() => saving == true);       

        saving = true;
        GameObject.Find("SceneManager").GetComponent<DatabaseManager>().ChangeStudentQuick(studentQuick);
        yield return new WaitWhile(() => saving == true);

        oldStudentMain = (StudentMain)oldStudentMain.Clone();
        oldStudentAlgo = (StudentAlgo)oldStudentAlgo.Clone();

        GameObject.Find("SceneManager").GetComponent<UserNavigation>().SaveDone();
    }

    public void CancelMainDataChanges()
    {
        FillInMainData(oldStudentMain);
        FillInAlgoData(oldStudentAlgo);
    }

    public void FillInMainData(StudentMain studentMain)
    {
        ManagerObject = GameObject.Find("SceneManager");
        oldStudentMain = (StudentMain)studentMain.Clone();

        nameBlock.GetComponent<BlockScript>().SetStringData(studentMain.Name);
        surnameBlock.GetComponent<BlockScript>().SetStringData(studentMain.Surname);
        birthdayBlock.GetComponent<BlockScript>().SetStringData(studentMain.Birthday);
        phoneNumberBlock.GetComponent<BlockScript>().SetStringData(studentMain.Phone);
        workBlock.GetComponent<BlockScript>().SetStringData(studentMain.Work);

        string gender = genderBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Gender));
        string origin = originBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Origin));
        string home = homeBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Residence));
        string destination = destinationBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Destination));
        string goal = whatYouDoBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Goal));
        string study = studyBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentMain.Faculty));

        ManagerObject.GetComponent<UserManager>().gender.text = gender;
        ManagerObject.GetComponent<UserManager>().origin.text = origin;
        ManagerObject.GetComponent<UserManager>().residence.text = home;
        ManagerObject.GetComponent<UserManager>().mobilityLocation.text = destination;
        //ManagerObject.GetComponent<UserManager>().goal.text = goal;
        ManagerObject.GetComponent<UserManager>().study.text = study;
    }

    public void FillInAlgoData(StudentAlgo studentAlgo)
    {
        oldStudentAlgo = (StudentAlgo)studentAlgo.Clone();

        string pets = petsBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentAlgo.Pets));
        string smoking = smokingBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentAlgo.Smoking));
        string guests = guestsBlock.GetComponent<BlockScript>().SetIntData(int.Parse(studentAlgo.Guests));
        string languages = languagesBlock.GetComponent<OptionsScript>().SetStringData(studentAlgo.Languages);

        ManagerObject.GetComponent<UserManager>().languages.text = languages;
        ManagerObject.GetComponent<UserManager>().pets.text = pets;
        ManagerObject.GetComponent<UserManager>().smoking.text = smoking;
        ManagerObject.GetComponent<UserManager>().guests.text = guests;
    }

    public string GetAge(string dateInput)
    {
        DateTime date;
        DateTime today = DateTime.Today;
        DateTime.TryParse(dateInput, out date);

        int age = today.Year - date.Year;
        if (date.Date > today.AddYears(-age)) age--;
        return age.ToString();
    }
}
