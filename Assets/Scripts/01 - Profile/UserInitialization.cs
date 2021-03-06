﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInitialization : MonoBehaviour
{
    public bool testing = false;

    public GameObject menuBottom;

    private void Start()
    {
        menuBottom.GetComponent<AppNavigation>().InitializeAppNavigation("PROFILE");
        gameObject.GetComponent<DatabaseManager>().FindDatabase();

        if (testing)
        {
            // Load scene data
            gameObject.GetComponent<UserManager>().LoadScene();
        }

        // Initialize scene navigation
        gameObject.GetComponent<UserNavigation>().InitializeSceneNavigation();
        
    }
}
