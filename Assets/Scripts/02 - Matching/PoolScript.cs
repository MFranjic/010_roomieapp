using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    public GameObject personPrefab;

    public Transform spawnPoint = null;


    public float SpawnPointDistanceFromFilters;
    public float PersonHeigth;
    public float Padding;
    public float FiltersHeight;

    private string currentUserID;
    private int numOfUsers;

    public void InitializePool(string userID, List<StudentAlgo> studentAlgoList, List<StudentQuick> studentQuickList)
    {
        numOfUsers = 0;
        currentUserID = userID;
        foreach (StudentQuick student in studentQuickList)
        {
            if (!student.GetEmail().Equals(currentUserID))
            {
                GameObject SpawnedItem = Instantiate(personPrefab, spawnPoint.localPosition, spawnPoint.rotation);

                SpawnedItem.transform.SetParent(spawnPoint, false);

                //get ItemDetails Component
                SpawnedItem.GetComponent<PersonScript>().SetPersonData(student.GetEmail(), student);
                numOfUsers++;
            }            
        }
        CalculateHeight();
    }

    private void CalculateHeight()
    {
        Vector2 delta = gameObject.GetComponent<RectTransform>().sizeDelta;
        float sum = SpawnPointDistanceFromFilters + FiltersHeight + numOfUsers / 3 * (PersonHeigth + Padding);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, sum);

        GameObject child = gameObject.transform.GetChild(1).gameObject;
        delta = child.GetComponent<RectTransform>().sizeDelta;
        child.GetComponent<RectTransform>().sizeDelta = new Vector2(360, sum - FiltersHeight);
    }
}
