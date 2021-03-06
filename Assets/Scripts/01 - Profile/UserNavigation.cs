﻿using System.Collections;
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

    public ScrollRect scrollRect;

    [SerializeField]
    private string currentState;

    [SerializeField]
    private bool editingActive;

    private bool saving = false;

    public void InitializeSceneNavigation()
    {
        ButtonRandom.onClick.AddListener(RandomizeGrid);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);
        RoomGrid.GetComponent<GridScript>().CancelEdit();
        PersonGrid.GetComponent<GridScript>().CancelEdit();

        // Initial navigation is: ROOM -> PERSON -> PROFILE
        // Because of options loading
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
            case "PROFILE":
                MainGrid.SetActive(false);
                return;
            case "ROOM":
                RoomGrid.SetActive(false);
                return;
            case "PERSON":
                PersonGrid.SetActive(false);
                return;
            default:
                MainGrid.SetActive(false);
                RoomGrid.SetActive(false);
                PersonGrid.SetActive(false);
                return;
        }
    }

    private void NavigateMain_StartNext(string nextState)
    {
        switch (nextState)               // initialize next state
        {
            case "PROFILE":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
                MainGrid.SetActive(true);
                return;
            case "ROOM":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)RoomGrid.transform;
                RoomGrid.SetActive(true);
                return;
            case "PERSON":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)PersonGrid.transform;
                PersonGrid.SetActive(true);
                return;
        }
    }

    public void NavigateEdit(bool saveChanges)
    {
        editingActive = !editingActive;

        if (editingActive)                   // turning EDIT ON
        {
            NavigateEdit_EditON();

            ButtonEdit.gameObject.SetActive(false);
            ButtonSave.gameObject.SetActive(true);
            ButtonCancel.gameObject.SetActive(true);
            MenuTop.gameObject.SetActive(false);
            MenuBottom.gameObject.SetActive(false);
        }
        else                            // turning EDIT OFF
        {
            if (saveChanges)            // SAVE if needed
            {
                StartCoroutine(NavigateEdit_Save());
            }
            else
            {
                NavigateEdit_Cancel();
                ButtonsBackToNormal();
            }         
        }

        scrollRect.normalizedPosition = new Vector2(0, 1);
    }

    private void NavigateEdit_EditON()
    {       
        switch (currentState)
        {
            case "PROFILE":
                UserData.GetComponent<ScrollRect>().content = (RectTransform)EditUserGrid.transform;
                MainGrid.SetActive(false);
                EditUserGrid.SetActive(true);
                return;
            case "ROOM":
                RoomGrid.GetComponent<GridScript>().ActivateEdit();
                return;
            case "PERSON":
                PersonGrid.GetComponent<GridScript>().ActivateEdit();
                return;
        }
    }

    private void NavigateEdit_Cancel()
    {
        switch (currentState)
        {
            case "PROFILE":
                EditUserGrid.GetComponent<EditMainData>().CancelMainDataChanges();
                UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
                MainGrid.SetActive(true);
                EditUserGrid.SetActive(false);
                return;
            case "ROOM":
                RoomGrid.GetComponent<GridScript>().CancelEdit();
                return;
            case "PERSON":
                PersonGrid.GetComponent<GridScript>().CancelEdit();
                return;
        }
    }

    IEnumerator NavigateEdit_Save()
    {
        if (currentState == "PROFILE")
        {
            if (!EditUserGrid.GetComponent<NewProfileManager>().CheckForErrors())
            {
                saving = true;

                EditUserGrid.GetComponent<EditMainData>().SaveMainDataChanges();
                yield return new WaitWhile(() => saving == true);

                UserData.GetComponent<ScrollRect>().content = (RectTransform)MainGrid.transform;
                MainGrid.SetActive(true);
                EditUserGrid.SetActive(false);

                gameObject.GetComponent<UserManager>().LoadScene();
                ButtonsBackToNormal();
            }
        }
        else if (currentState == "ROOM")
        {
            RoomGrid.GetComponent<GridScript>().SaveChanges();
            ButtonsBackToNormal();
        }
        else if (currentState == "PERSON")
        {
            PersonGrid.GetComponent<GridScript>().SaveChanges();
            ButtonsBackToNormal();
        }     
    }

    private void ButtonsBackToNormal()
    {
        ButtonEdit.gameObject.SetActive(true);
        ButtonSave.gameObject.SetActive(false);
        ButtonCancel.gameObject.SetActive(false);
        MenuTop.gameObject.SetActive(true);
        MenuBottom.gameObject.SetActive(true);
    }

    public void SaveDone()
    {
        saving = false;
    }

    public void RandomizeGrid()
    {
        switch (currentState)
        {
            case "ROOM":
                RoomGrid.GetComponent<GridScript>().RandomSelection();
                return;
            case "PERSON":
                PersonGrid.GetComponent<GridScript>().RandomSelection();
                return;
        }
    }
}
