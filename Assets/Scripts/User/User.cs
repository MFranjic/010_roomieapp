using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class User
{
    // General data
    public string Name;
    public string Surname;
    public string City;
    public string Country;
    public string Gender;
    public DateTime DateOfBirth;

    // Contact data
    public string Email;
    public string PhoneNumber;

    // Other data
    public string FieldOfStudy;
    public string ZagrebFaculty;
    public DateTime Arrival;
    public DateTime Departure;
    public string Description;

    public string[] Languages;
    public string[] Interests;
    public int[] SlidersValues;

    // Apartment questions
    public string Apartment1;
    public string Apartment2;
    public string Apartment3;
    public string Apartment4;
    public string Apartment5;

    // People questions
    public string People1;
    public string People2;
    public string People3;
    public string People4;
    public string People5;

    private User() { }

    public User(string name, string surname, string email)
    {
        Name = name;
        Surname = surname;
        Email = email;
    }

    override
    public string ToString()
    {
        return Name + ", " + Surname + ", " + Email;
    }

    public string GetDateOfBirth()
    {
        return DateOfBirth.ToString("dd/MM/yyyy");
    }

    public string GetArrivalMonth()
    {
        return Arrival.ToString("MM/yyyy");
    }

    public string GetDepartureMonth()
    {
        return Departure.ToString("MM/yyyy");
    }

    public void AddApartmentAnswers(string apartment1, string apartment2, string apartment3, string apartment4, string apartment5)
    {
        Apartment1 = apartment1;
        Apartment2 = apartment2;
        Apartment3 = apartment3;
        Apartment4 = apartment4;
        Apartment5 = apartment5;
    }

    public void AddPeopleAnswers(string people1, string people2, string people3, string people4, string people5)
    {
        People1 = people1;
        People2 = people2;
        People3 = people3;
        People4 = people4;
        People5 = people5;
    }

    public string FetchLanguages()
    {
        string languages = "";
        foreach(string language in Languages)
        {
            languages += language;
            if (!language.Equals(Languages[Languages.Length - 1]))
            {
                languages += ",";
            }
        }
        return languages;
    }

    public string FetchInterests()
    {
        string interests = "";
        foreach (string interest in Interests)
        {
            interests += interest;
            if (!interest.Equals(Interests[Interests.Length - 1]))
            {
                interests += ",";
            }
        }
        return interests;
    }

    public string FetchSliders()
    {
        string sliders = "";
        foreach (int sliderValue in SlidersValues)
        {
            sliders += sliderValue;
            if (!sliderValue.Equals(SlidersValues[SlidersValues.Length - 1]))
            {
                sliders += ",";
            }
        }
        return sliders;
    }
}
