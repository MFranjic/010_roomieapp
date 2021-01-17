using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Auth;
using Firebase.Extensions;

public class InitializeUser : MonoBehaviour
{
    public TMP_Text username;

    private void Start()
    {
        username.text = FirebaseAuth.DefaultInstance.CurrentUser.Email;
    }
}
