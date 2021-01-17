using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;

public class NewUser : MonoBehaviour
{
    public TMP_InputField nameIF;
    public TMP_InputField surnameIF;
    public TMP_InputField emailIF;
    public Button saveButton;

    private DatabaseReference database;

    private void Start()
    {
        database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void AddNewUser()
    {
        Debug.Log("Button clicked");

        string name = nameIF.text;
        string surname = surnameIF.text;
        string email = emailIF.text;

        Debug.Log(name + surname + email);

        User newUser = new User(name, surname, email);
        string json = JsonUtility.ToJson(newUser);

        Debug.Log(json);

        database.Child("users").Child("1").SetRawJsonValueAsync(json).ContinueWithOnMainThread((task) => 
        { 
            if(task.IsCompleted)
            {
                SceneManager.LoadScene("UserScene");
            }
        });
    }
}
