using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAlgo
{
    public string Languages;
    public string Pets;
    public string Smoking;
    public string Guests;
    public string Budget;
    public string Location;
    public string Type;
    public string Rules;
    public string Interests;
    public string Preferences;
    public string Habbits_Me;
    public string Habbits_Other;
    public string Prio;

    private string Email;

    public StudentAlgo(string email, string languages, string pets, string smoking, string guests)
    {
        Email = email;
        Languages = languages;
        Pets = pets;
        Smoking = smoking;
        Guests = guests;
    }

    public string GetEmail()
    {
        return Email;
    }
}
