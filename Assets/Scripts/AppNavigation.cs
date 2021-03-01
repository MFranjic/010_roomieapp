using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppNavigation : MonoBehaviour
{
    public Button NewsFeedButton;
    public Button MyProfileButton;
    public Button MatchingButton;
    public Button ApartmantsButton;
    public Button SettingsButton;

    public Color activatedButtonColor;

    public void InitializeAppNavigation(string sceneID)
    {
        switch(sceneID)
        {
            case "FEED":
                SetButtonColor(NewsFeedButton);
                return;
            case "PROFILE":
                SetButtonColor(MyProfileButton);
                return;
            case "MATCHING":
                SetButtonColor(MatchingButton);
                return;
            case "APARTMANTS":
                SetButtonColor(ApartmantsButton);
                return;
        }
    }

    private void SetButtonColor(Button button)
    {
        button.gameObject.GetComponent<Image>().color = activatedButtonColor;
        Canvas.ForceUpdateCanvases();
        /*var colors = button.colors;
        colors.normalColor = activatedButtonColor;
        button.colors = colors;*/
    }

    public void ActivateSettings()
    {

    }

    public void SetNewsFeed()
    {

    }

    public void SetMyProfile()
    {
        SceneManager.LoadScene("UserScene");
    }

    public void SetMatching()
    {
        SceneManager.LoadScene("MatchingScene");
    }

    public void SetApartments()
    {

    } 
}
