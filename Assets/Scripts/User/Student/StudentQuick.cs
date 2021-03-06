﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentQuick
{
    public string Name;
    public string Country;
    public string Age;
    public string Gender;

    private string Email;

    public StudentQuick(string name, string email, string country, string age, string gender)
    {
        Name = name;
        Email = email;
        Country = country;
        Age = age;
        Gender = gender;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public string GetEmail()
    {
        return Email;
    }
}
