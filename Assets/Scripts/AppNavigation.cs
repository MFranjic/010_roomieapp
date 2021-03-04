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

    public Sprite MyProfileON;
    public Sprite MyProfileOFF;
    public Sprite MatchingON;
    public Sprite MatchingOFF;

    public void InitializeAppNavigation(string sceneID)
    {
        switch(sceneID)
        {
            case "FEED":
                //SetButtonColor(NewsFeedButton);
                return;
            case "PROFILE":
                MyProfileButton.GetComponent<Button>().image.sprite = MyProfileON;
                MatchingButton.GetComponent<Button>().image.sprite = MatchingOFF;
                return;
            case "MATCHING":
                MyProfileButton.GetComponent<Button>().image.sprite = MyProfileOFF;
                MatchingButton.GetComponent<Button>().image.sprite = MatchingON;
                return;
            case "APARTMANTS":
                //SetButtonColor(ApartmantsButton);
                return;
        }
    }

    public void QuitApp()
    {
        Application.Quit();
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
