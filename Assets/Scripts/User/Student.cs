﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : User
{
    // General data
    public string Gender { get; set; }
    public string Age { get; set; }
    public string HomeCountry { get; set; }
    public string HomeCity { get; set; }
    public string OutgoingCountry { get; set; }
    public string OutgoingCity { get; set; }

    // Contact data
    public string FacebookLink { get; set; }
    public string InstagramLink { get; set; }

    public Student(string name, string surname, string email, string gender, string age): base(name, surname, email)
    {
        Gender = gender;
        Age = age;
    }
}
