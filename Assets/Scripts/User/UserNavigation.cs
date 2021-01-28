using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserNavigation : MonoBehaviour
{
    public Button MainButton;
    public Button RoomButton;
    public Button PersonButton;

    public GameObject UserData;
    public TMP_Text TitleText;

    public GameObject MainGrid;
    public GameObject RoomGrid;
    public GameObject PersonGrid;

    public Button ChangeDataButton;

    private void Start()
    {
        MainButton.onClick.AddListener(SwitchToMain);
        RoomButton.onClick.AddListener(SwitchToRoom);
        PersonButton.onClick.AddListener(SwitchToPerson);
    }

    private void SwitchToMain()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
        MainGrid.SetActive(true);
        RoomGrid.SetActive(false);
        PersonGrid.SetActive(false);
        TitleText.text = "Main info";

        ChangeDataButton.gameObject.SetActive(true);
    }

    private void SwitchToRoom()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)RoomGrid.transform;
        MainGrid.SetActive(false);
        RoomGrid.SetActive(true);
        PersonGrid.SetActive(false);
        TitleText.text = "Apartment info";

        ChangeDataButton.gameObject.SetActive(false);
    }

    private void SwitchToPerson()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)PersonGrid.transform;
        MainGrid.SetActive(false);
        RoomGrid.SetActive(false);
        PersonGrid.SetActive(true);
        TitleText.text = "Roommate info";

        ChangeDataButton.gameObject.SetActive(false);
    }
}
