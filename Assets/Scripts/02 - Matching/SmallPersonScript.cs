using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SmallPersonScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text genderText;
    public TMP_Text countryText;    

    public Button buttonLink;

    private string personID;

    private void Start()
    {
        buttonLink.onClick.AddListener(OpenPersonDetails);
    }

    private void OpenPersonDetails()
    {
        //Debug.Log("Searching for: " + personID);
        GameObject.Find("SceneManager").GetComponent<MatchingNavigation>().Navigate_Details(personID);
    }

    public void SetPersonData(string personID, StudentQuick person)
    {
        this.personID = personID;

        nameText.text = person.Name;
        ageText.text = person.Age;
        countryText.text = person.Country;
        switch (person.Gender)
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
}
