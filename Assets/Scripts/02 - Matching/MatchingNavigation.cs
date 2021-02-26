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
    public GameObject MatchesGrid;

    public GameObject MenuTop;
    public GameObject MenuBottom;

    public ScrollRect scrollRect;

    [SerializeField]
    private string currentState;

    public void InitializeSceneNavigation()
    {
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
            case "MATCHES":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)MatchesGrid.transform;
                MatchesGrid.SetActive(true);
                return;
        }
    }
}
