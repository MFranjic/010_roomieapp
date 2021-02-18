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

    public GameObject EditUserGrid;
    public GameObject MainGrid;   
    public GameObject RoomGrid;
    public GameObject PersonGrid;

    public Button ButtonEdit;
    public Button ButtonSave;
    public Button ButtonCancel;
    public Button ButtonRandom;

    public GameObject MenuTop;
    public GameObject MenuBottom;

    private bool mainActive = false;
    private bool roomActive = false;
    private bool personActive = false;

    private void Start()
    {
        MainButton.onClick.AddListener(SwitchToMain);
        RoomButton.onClick.AddListener(SwitchToRoom);
        PersonButton.onClick.AddListener(SwitchToPerson);

        ButtonEdit.onClick.AddListener(ClickEdit);
        ButtonSave.onClick.AddListener(ClickSave);
        ButtonCancel.onClick.AddListener(ClickCancel);

        ButtonRandom.onClick.AddListener(RandomizeGrid);

        SwitchToMain();
        RoomGrid.GetComponent<GridScript>().CancelEdit();
        PersonGrid.GetComponent<GridScript>().CancelEdit();
    }

    public void RandomizeGrid()
    {
        if(roomActive)
        {
            RoomGrid.GetComponent<GridScript>().RandomSelection();
        }
        else if (personActive)
        {
            PersonGrid.GetComponent<GridScript>().RandomSelection();
        }
    }

    public void ClickEdit()
    {
        if(mainActive)
        {
            UserData.GetComponent<ScrollRect>().content = (RectTransform)EditUserGrid.transform;
            MainGrid.SetActive(false);
            EditUserGrid.SetActive(true);
        }
        else if (roomActive)
        {
            RoomGrid.GetComponent<GridScript>().ActivateEdit();
        }
        else if (personActive)
        {
            PersonGrid.GetComponent<GridScript>().ActivateEdit();
        }

        ButtonEdit.gameObject.SetActive(false);
        ButtonSave.gameObject.SetActive(true);
        ButtonCancel.gameObject.SetActive(true);

        MenuTop.gameObject.SetActive(false);
        MenuBottom.gameObject.SetActive(false);
    }

    public void ClickSave()
    {
        if (mainActive)
        {
            UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
            MainGrid.SetActive(true);
            EditUserGrid.SetActive(false);
        }
        else if (roomActive)
        {
            RoomGrid.GetComponent<GridScript>().SaveChanges();
        }
        else if (personActive)
        {
            PersonGrid.GetComponent<GridScript>().SaveChanges();
        }

        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);

        MenuTop.gameObject.SetActive(true);
        MenuBottom.gameObject.SetActive(true);
    }

    public void ClickCancel()
    {
        if (mainActive)
        {
            UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
            MainGrid.SetActive(true);
            EditUserGrid.SetActive(false);
        }
        else if (roomActive)
        {
            RoomGrid.GetComponent<GridScript>().CancelEdit();
        }
        else if (personActive)
        {
            PersonGrid.GetComponent<GridScript>().CancelEdit();
        }

        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);

        MenuTop.gameObject.SetActive(true);
        MenuBottom.gameObject.SetActive(true);
    }

    private void SwitchToMain()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
        MainGrid.SetActive(true);
        EditUserGrid.SetActive(false);
        RoomGrid.SetActive(false);
        PersonGrid.SetActive(false);

        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);
        
        mainActive = true;
        roomActive = false;
        personActive = false;
    }

    private void SwitchToRoom()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)RoomGrid.transform;
        MainGrid.SetActive(false);
        EditUserGrid.SetActive(false);
        RoomGrid.SetActive(true);
        PersonGrid.SetActive(false);

        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);

        mainActive = false;
        roomActive = true;
        personActive = false;
    }

    private void SwitchToPerson()
    {
        UserData.GetComponent<ScrollRect>().content = (RectTransform)PersonGrid.transform;
        MainGrid.SetActive(false);
        EditUserGrid.SetActive(false);
        RoomGrid.SetActive(false);
        PersonGrid.SetActive(true);

        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);

        mainActive = false;
        roomActive = false;
        personActive = true;
    }
}
