using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeMainData : MonoBehaviour
{
    public Text changeDataButtonTxt;

    public GameObject nameIF;
    public GameObject surnameIF;
    public GameObject emailIF;
    public GameObject phoneIF;
    public GameObject genderDD;
    public GameObject countryDD;
    public GameObject cityIF;

    public GameObject facultyDD;
    public GameObject arrivalDD;
    public GameObject depratureDD;
    public GameObject descriptionIF;

    private bool editingEnabled;

    private void Start()
    {
        editingEnabled = false;
    }

    public void SwitchInputFields()
    {
        editingEnabled = !editingEnabled;
        if(editingEnabled)
        {
            FieldsEnable();
            changeDataButtonTxt.text = "Save data";
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
        else
        {
            FieldsDisable();
            changeDataButtonTxt.text = "Change data";
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        }
    }

    private void FieldsEnable()
    {
        nameIF.SetActive(true);
        surnameIF.SetActive(true);
        emailIF.SetActive(true);
        phoneIF.SetActive(true);
        genderDD.SetActive(true);
        countryDD.SetActive(true);
        cityIF.SetActive(true);
        facultyDD.SetActive(true);
        arrivalDD.SetActive(true);
        depratureDD.SetActive(true);
        descriptionIF.SetActive(true);
    }

    private void FieldsDisable()
    {
        nameIF.SetActive(false);
        surnameIF.SetActive(false);
        emailIF.SetActive(false);
        phoneIF.SetActive(false);
        genderDD.SetActive(false);
        countryDD.SetActive(false);
        cityIF.SetActive(false);
        facultyDD.SetActive(false);
        arrivalDD.SetActive(false);
        depratureDD.SetActive(false);
        descriptionIF.SetActive(false);
    }
}
