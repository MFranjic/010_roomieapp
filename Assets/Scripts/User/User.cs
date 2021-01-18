using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    // General data
    public string Name;
    public string Surname;



    // Contact data
    //public string PhoneNumber { get; set; }
    public string Email;
    
    // Other data
    public string Description { get; set; }

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
}
