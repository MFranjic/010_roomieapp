using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeMainData : MonoBehaviour
{
    public TMP_InputField nameIF;
    public TMP_InputField surnameIF;
    public TMP_InputField emailIF;
    public TMP_InputField phoneIF;
    public TMP_Dropdown genderDD;
    public TMP_Dropdown countryDD;
    public TMP_InputField cityIF;

    public TMP_Dropdown facultyDD;
    public TMP_Dropdown arrivalDD;
    public TMP_Dropdown depratureDD;
    public TMP_InputField descriptionIF;

    public void ActivateInputFields()
    {
        FieldsEnable();
    }

    private void FieldsEnable()
    {
        nameIF.enabled = true;
        surnameIF.enabled = true;
        emailIF.enabled = true;
        phoneIF.enabled = true;
        genderDD.enabled = true;
        countryDD.enabled = true;
        cityIF.enabled = true;
        facultyDD.enabled = true;
        arrivalDD.enabled = true;
        depratureDD.enabled = true;
        descriptionIF.enabled = true;
    }

    private void FieldsDisable()
    {
        nameIF.enabled = false;
        surnameIF.enabled = false;
        emailIF.enabled = false;
        phoneIF.enabled = false;
        genderDD.enabled = false;
        countryDD.enabled = false;
        cityIF.enabled = false;
        facultyDD.enabled = false;
        arrivalDD.enabled = false;
        depratureDD.enabled = false;
        descriptionIF.enabled = false;
    }
}
