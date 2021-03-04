using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentMain : ICloneable
{
    public string Name;
    public string Surname;
    public string Gender;
    public string Birthday;
    public string Origin;
    public string Residence;
    public string Destination;
    public string Phone;
    public string Goal;
    public string Faculty;
    public string Work;
    public string Photo;
    public string Description;

    private string Email;

    public StudentMain(string name, string surname, string email, string gender, string birthday, string origin, 
                       string residence, string destination, string phone, string goal, string faculty, string work)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Gender = gender;
        Birthday = birthday;
        Origin = origin;
        Residence = residence;
        Destination = destination;
        Phone = phone;
        Goal = goal;
        Faculty = faculty;
        Work = work;
    }

    public StudentMain(string name, string surname, string email, string gender, string birthday, string origin,
                       string residence, string destination, string phone, string goal, string faculty, string work, string description, string photo)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Gender = gender;
        Birthday = birthday;
        Origin = origin;
        Residence = residence;
        Destination = destination;
        Phone = phone;
        Goal = goal;
        Faculty = faculty;
        Work = work;
        Description = description;
        Photo = photo;
    }

    public void ChangeStudentMain(string name, string surname, string gender, string birthday, string origin,
                       string residence, string destination, string phone, string goal, string faculty, string work)
    {
        Name = name;
        Surname = surname;
        Gender = gender;
        Birthday = birthday;
        Origin = origin;
        Residence = residence;
        Destination = destination;
        Phone = phone;
        Goal = goal;
        Faculty = faculty;
        Work = work;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void AddDescription(string description)
    {
        Description = description;
    }

    public void AddPhoto(string photoLink)
    {
        Photo = photoLink;
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
