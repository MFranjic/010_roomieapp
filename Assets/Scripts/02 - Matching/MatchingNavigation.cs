using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingNavigation : MonoBehaviour
{
    public Button SearchButton;
    public Button MatchesButton;

    public GameObject UserData;

    public GameObject SearchGrid;
    public GameObject DetailsGrid;
    public GameObject MatchesGrid;

    public GameObject MenuTop;
    public GameObject MenuBottom;
    public Button EditButton;
    public Button SaveButton;
    public Button CancelButton;

    public ScrollRect scrollRect;

    [SerializeField]
    private string currentState;

    public void InitializeSceneNavigation()
    {
        EditButton.gameObject.SetActive(false);
        SaveButton.gameObject.SetActive(false);
        CancelButton.gameObject.SetActive(false);

        currentState = "SEARCH";

        NavigateMain("SEARCH");
    }

    public void NavigateMain(string nextState)
    {
        NavigateMain_EndCurrent();
        NavigateMain_StartNext(nextState);
        currentState = nextState;

        scrollRect.normalizedPosition = new Vector2(0, 1);
    }

    private void NavigateMain_EndCurrent()
    {
        switch (currentState)            // end current state
        {
            case "SEARCH":
                SearchGrid.SetActive(false);
                return;
            case "DETAILS":
                DetailsGrid.SetActive(false);
                CancelButton.gameObject.SetActive(false);
                return;
            case "MATCHES":
                MatchesGrid.SetActive(false);
                return;
        }
    }

    private void NavigateMain_StartNext(string nextState)
    {
        switch (nextState)               // initialize next state
        {
            case "SEARCH":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)SearchGrid.transform;
                SearchGrid.SetActive(true);
                return;
            case "DETAILS":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)DetailsGrid.transform;
                DetailsGrid.SetActive(true);
                return;
            case "MATCHES":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)MatchesGrid.transform;
                MatchesGrid.SetActive(true);
                return;
        }
    }

    public void Navigate_Details(string userID)
    {
        NavigateMain("DETAILS");
        DetailsGrid.GetComponent<DetailsScript>().LoadScene(userID);

        CancelButton.gameObject.SetActive(true);
    }

    public void SendPin(string reciever)
    {
        MatchesGrid.GetComponent<MatchingDB>().Pin(gameObject.GetComponent<MatchingManager>().GetCurrentUser(), reciever);
    }

    public void SendRequest(string reciever)
    {
        MatchesGrid.GetComponent<MatchingDB>().Request(gameObject.GetComponent<MatchingManager>().GetCurrentUser(), reciever);
    }
}
