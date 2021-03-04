using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{
    public string testUserID;

    public GameObject gridPool;
    public GameObject gridDetails;

    private bool loading = false;

    private string userID;

    private List<StudentAlgo> studentAlgoList;
    private List<StudentQuick> studentQuickList;

    public void LoadScene()
    {
        FetchCurrentUser();
        StartCoroutine(FetchDataForPool());
        DoAlgorithm(userID);
    }

    public void GetDetailsMainFromDB(StudentMain studentMain)
    {
        gridDetails.GetComponent<DetailsScript>().LoadStudentMainFromDatabase(studentMain);
    }

    public void GetDetailsAlgoFromDB(StudentAlgo studentAlgo)
    {
        gridDetails.GetComponent<DetailsScript>().LoadStudentAlgoFromDatabase(studentAlgo);
    }

    public void GetStudentsQuickFromDB(List<StudentQuick> studentQuickList)
    {
        this.studentQuickList = studentQuickList;
        loading = false;
    }

    public void GetStudentsAlgoFromDB(List<StudentAlgo> studentAlgoList)
    {
        this.studentAlgoList = studentAlgoList;
        loading = false;
    }

    IEnumerator FetchDataForPool()
    {
        loading = true;
        //Debug.Log("Fetching1...");
        gameObject.GetComponent<DatabaseManager>().FetchAllAlgo();
        yield return new WaitWhile(() => loading == true);

        loading = true;
        //Debug.Log("Fetching2...");
        gameObject.GetComponent<DatabaseManager>().FetchAllQuick();
        yield return new WaitWhile(() => loading == true);

        gridPool.GetComponent<PoolScript>().InitializePool(userID, studentAlgoList, studentQuickList);
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
