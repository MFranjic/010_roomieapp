using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInfo : MonoBehaviour
{
    public GameObject nameBlock;

    public GameObject surnameBlock;

    public GameObject genderBlock;

    public GameObject birthdayBlock;

    public GameObject originBlock;

    public GameObject homeBlock;

    public GameObject destinationBlock;

    public GameObject phoneNumberBlock;
    public int phoneNumberLength;

    public GameObject whatYouDoBlock;

    public GameObject studyBlock;

    public GameObject workBlock;

    public GameObject languagesBlock;
    public int maxLanguages;

    public GameObject petsBlock;

    public GameObject smokingBlock;

    public GameObject guestsBlock;

    private string[] namesMale = new string[] { "John", "Marcus", "Sebastian", "Lucas", "Adam", "James", "Stefan", "Benjamin", "Jack", "David" };
    private string[] namesFemale = new string[] { "Amelia", "Mia", "Maria", "Sofia", "Emma", "Lucia", "Olivia", "Anna", "Hanna", "Lea" };

    private string[] surnames = new string[] { "Berger", "Peeters", "Novak", "Nielsen", "Schmidt", "Smith", "Moretti", "De Jong", "Larsen", "Kowalski",
                                               "Santos", "Gomes", "Nikolić", "Varga", "Garcia", "Fernandez", "Perez", "Walker", "Yilmaz", "Jones"};

    private string[] workPlace = new string[] { "My country's embassy", "Ericsson", "Programmer at Infobip", "Končar", "Building Bandić's fountains", "Doing whatever", "Still searching", "ESN intern", "Any travel agency internship", "Konzum" };

    private System.Random rnd;

    private string name;
    private string surname;
    private string gender;
    private string birthday;
    private string origin;
    private string home;
    private string destination;
    private string phone;
    private int whatYouDoIndex;
    private string study;
    private string work;
    private string languages;
    private int petsIndex;
    private int smokingIndex;
    private int guestsIndex;

    private string email = "mfranjic995@gmail.com";

    private void Start()
    {
        rnd = new System.Random();
    }

    public void GenerateUser()
    {
        // GENDER
        int genderIndex = GenerateIndex(genderBlock.GetComponent<BlockScript>().GetDropdownSize());
        gender = genderBlock.GetComponent<BlockScript>().SetIntData(genderIndex);

        // NAME     
        if (genderIndex != 0)
        {
            name = GenerateNameFemale();
        }
        else
        {
            name = GenerateNameMale();
        }
        nameBlock.GetComponent<BlockScript>().SetStringData(name);

        // SURNAME
        surname = GenerateSurname();
        surnameBlock.GetComponent<BlockScript>().SetStringData(surname);

        // BIRTHDAY
        birthday = GenerateDate();
        birthdayBlock.GetComponent<BlockScript>().SetStringData(birthday);

        // ORIGIN
        int originIndex = GenerateIndex(originBlock.GetComponent<BlockScript>().GetDropdownSize());
        origin = originBlock.GetComponent<BlockScript>().SetIntData(originIndex);

        // HOME
        int homeIndex = GenerateIndex(homeBlock.GetComponent<BlockScript>().GetDropdownSize());
        home = homeBlock.GetComponent<BlockScript>().SetIntData(homeIndex);

        // DESTINATION
        int destinationIndex = GenerateIndex(destinationBlock.GetComponent<BlockScript>().GetDropdownSize());
        destination = destinationBlock.GetComponent<BlockScript>().SetIntData(destinationIndex);

        // PHONE
        phone = GeneratePhoneNumber(phoneNumberLength);
        phoneNumberBlock.GetComponent<BlockScript>().SetStringData(phone);

        // WHATYOUDO
        whatYouDoIndex = GenerateIndex(3);
        whatYouDoBlock.GetComponent<BlockScript>().SetIntData(whatYouDoIndex);

        // STUDY
        study = "";
        if (whatYouDoIndex == 0 || whatYouDoIndex == 2)
        {
            int studyIndex = GenerateIndex(studyBlock.GetComponent<BlockScript>().GetDropdownSize());
            study = studyBlock.GetComponent<BlockScript>().SetIntData(studyIndex);
        }

        // WORK
        work = "";
        if (whatYouDoIndex == 1 || whatYouDoIndex == 2)
        {
            work = GenerateWorkplace();
            workBlock.GetComponent<BlockScript>().SetStringData(work);
        }

        // LANGUAGES
        languages = languagesBlock.GetComponent<OptionsScript>().CreateRandomOptions(GenerateIndex(maxLanguages) + 1);

        // PETS
        petsIndex = GenerateIndex(petsBlock.GetComponent<BlockScript>().GetDropdownSize());
        petsBlock.GetComponent<BlockScript>().SetIntData(petsIndex);

        // SMOKING
        smokingIndex = GenerateIndex(smokingBlock.GetComponent<BlockScript>().GetDropdownSize());
        smokingBlock.GetComponent<BlockScript>().SetIntData(smokingIndex);

        // GuESTS
        guestsIndex = GenerateIndex(guestsBlock.GetComponent<BlockScript>().GetDropdownSize());
        guestsBlock.GetComponent<BlockScript>().SetIntData(guestsIndex);
    }

    public void SaveUser()
    {
        StudentMain newStudentMain = new StudentMain(name, surname, name + surname, gender, birthday, origin, home, destination, phone, whatYouDoIndex.ToString(), study, work);
        StudentQuick newStudentQuick = new StudentQuick(name, name + surname, home, GetAge(birthday), gender);
        StudentAlgo newStudentAlgo = new StudentAlgo(name + surname, languages, petsIndex.ToString(), smokingIndex.ToString(), guestsIndex.ToString());

        gameObject.GetComponent<DatabaseManager>().AddStudentMain(newStudentMain);
        gameObject.GetComponent<DatabaseManager>().AddStudentQuick(newStudentQuick);
        gameObject.GetComponent<DatabaseManager>().AddStudentAlgo(newStudentAlgo);
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

    private string GenerateNameMale()
    {
        
        int i = rnd.Next(namesMale.Length);
        return namesMale[i];
    }

    private string GenerateNameFemale()
    {
        int i = rnd.Next(namesFemale.Length);
        return namesFemale[i];
    }

    private string GenerateSurname()
    {
        int i = rnd.Next(surnames.Length);
        return surnames[i];
    }

    private string GenerateDate()
    {
        string date = rnd.Next(30) + "/" + rnd.Next(12) + "/" + rnd.Next(1990, 2004);
        return date;
    }

    private string GenerateWorkplace()
    {
        int i = rnd.Next(workPlace.Length);
        return workPlace[i];
    }

    private int GenerateIndex(int size)
    {
        return rnd.Next(size);
    }

    private string GeneratePhoneNumber(int size)
    {
        string number = "+";
        for (int i = 0; i < 3; i++)
        {
            number += rnd.Next(10).ToString();
        }
        number += " ";
        for (int i = 0; i < size - 3; i++)
        {
            number += rnd.Next(10).ToString();
        }
        return number;
    }
}
