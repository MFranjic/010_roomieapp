using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DateValidation : MonoBehaviour
{
    public TMP_Text dateText;

    public bool isValidated()
    {
        DateTime value;
        if (DateTime.TryParse(dateText.text, out value))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
