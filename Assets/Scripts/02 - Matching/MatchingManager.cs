using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{
    public string testUserID;

    private bool loading = false;

    private string userID;

    public void LoadScene()
    {
        //StartCoroutine(LoadData());
        FetchCurrentUser();
        DoAlgorithm(userID);
    }

    public void FilterPool(string filterID)
    {
        // go through all spawned objects
        // in their script - send filterID
        // depending on the filterID turn on or off the objects
    }

    private void FetchCurrentUser()
    {
        // setting userID
        userID = testUserID;
    }

    private void DoAlgorithm(string user)
    {
        // fetch all algo data
        // fetch all quick data
        
        // set user algo data from all data
        // for every student - calculate percentage and put in sorting list
        // for every input in sorting list:
            // get the needed data from quick data
            // initialize new object and put to pool
    }

    private float CalculatePercentage(StudentAlgo algoData)
    {
        float percentage = 0;

        // algorithm that calculates simmilarities between user and the other student

        return percentage;
    }
}
