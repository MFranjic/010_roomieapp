using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;

public class FetchUser : MonoBehaviour
{
    public TMP_Text nameTxt;
    public TMP_Text surnameTxt;
    public TMP_Text emailTxt;

    private DatabaseReference databaseReference;

    private void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        databaseReference.Child("users").Child("1").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("FirebaseDatabaseError: IsCanceled: " + task.Exception);
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("FirebaseDatabaseError: IsFaulted:" + task.Exception);
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                User user = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());

                Debug.Log(user.ToString());
                
                nameTxt.text = user.Name;              
                surnameTxt.text = user.Surname;
                emailTxt.text = user.Email;
            }
        });
    }
}
