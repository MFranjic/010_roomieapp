using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PersonScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text countryText;
    public TMP_Text genderText;
    public TMP_Text percentageText;

    public Button buttonLink;

    private float percentage;
    private string personID;

    public void SetPersonData(string personID, StudentQuick person)
    {
        this.personID = personID;

        nameText.text = person.Name;
        ageText.text = person.Age;
        countryText.text = person.Country;
        switch(person.Gender)
        {
            case "Male": 
                genderText.text = "M";
                return;
            case "Female":
                genderText.text = "F";
                return;
            case "Non-binary":
                genderText.text = "NB";
                return;
            case "Prefer not to say":
                genderText.text = "-";
                return;
        }
    }

    public void SetPersonPercentage(float percentage)
    {
        this.percentage = percentage;
        percentageText.text = percentage.ToString("0.0") + " %";
    }

    public bool TestFilter(string filterID)
    {
        bool filterPassed = false;
        switch(filterID)
        {
            // filters
        }

        if(!filterPassed)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

        return filterPassed;
    }

    public float GetPersonPercentage()
    {
        return percentage;
    }

    public void GetPersonDetails()
    {
        // Find SceneManager
        // for personID - find StudentMain in DB - open view with that data
    }
}
