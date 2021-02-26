using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingInitialization : MonoBehaviour
{
    public bool testing = false;

    private void Start()
    {
        gameObject.GetComponent<DatabaseManager>().FindDatabase();

        if (testing)
        {
            // Load scene data
            gameObject.GetComponent<MatchingManager>().LoadScene();
        }

        // Initialize scene navigation
        gameObject.GetComponent<MatchingNavigation>().InitializeSceneNavigation();
    }
}
