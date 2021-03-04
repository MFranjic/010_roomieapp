using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAlgo : ICloneable
{
    public string Languages;
    public string Pets;
    public string Smoking;
    public string Guests;
    public string Budget;
    public string Type;
    public string Location;
    public string Rules;
    public string Interests;
    public string Preferences;
    public string Habbits_Me;
    public string Habbits_Other;
    public string Activities;
    public string Prio;

    private string Email;
    private int[] SliderValues;

    public StudentAlgo(string email, string languages, string pets, string smoking, string guests)
    {
        Email = email;
        Languages = languages;
        Pets = pets;
        Smoking = smoking;
        Guests = guests;

        Budget = Type = Location = Rules = Interests = Preferences = Habbits_Me = Habbits_Other = Activities = "";
        Prio = "0-0-0-0-0-0-0-0-0";
    }

    public void ChangeStudentAlgo(string languages, string pets, string smoking, string guests)
    {
        Languages = languages;
        Pets = pets;
        Smoking = smoking;
        Guests = guests;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public string GetEmail()
    {
        return Email;
    }

    public string GetProperty(int index)
    {
        switch (index)
        {
            case 0:
                return Budget;
            case 1:
                return Type;
            case 2:
                return Location;
            case 3:
                return Rules;
            case 4:
                return Interests;
            case 5:
                return Preferences;
            case 6:
                return Habbits_Me;
            case 7:
                return Habbits_Other;
            case 8:
                return Activities;
        }
        return null;
    }

    public int GetSliderValue(int index)
    {
        return SliderValues[index];
    }

    public void ParsePrio()
    {
        SliderValues = new int[9];
        string[] parsedPrio = Prio.Split('-');    
        for (int i = 0; i < parsedPrio.Length; i++)
        {
            SliderValues[i] = int.Parse(parsedPrio[i]);
        }
    }

    public void SetProperty(int index, string data, int slider)
    {
        SliderValues[index] = slider;
        switch (index)
        {
            case 0:
                Budget = data;
                return;
            case 1:
                Type = data;
                return;
            case 2:
                Location = data;
                return;
            case 3:
                Rules = data;
                return;
            case 4:
                Interests = data;
                return;
            case 5:
                Preferences = data;
                return;
            case 6:
                Habbits_Me = data;
                return;
            case 7:
                Habbits_Other = data;
                return;
            case 8:
                Activities = data;
                return;
        }       
    }

    public void SetPrioDataString()
    {       
        Prio = "";
        for (int i = 0; i < 9; i++)
        {
            Prio += SliderValues[i];
            if (i != 8)
            {
                Prio += "-";
            }
        }
    }
}
