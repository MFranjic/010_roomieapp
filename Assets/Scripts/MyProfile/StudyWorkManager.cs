using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StudyWorkManager : MonoBehaviour
{
    public GameObject studyBlock;
    public GameObject workBlock;

    public GameObject blockContainer;

    public GameObject buttonStudy;
    public GameObject buttonWork;
    public GameObject buttonBoth;

    private bool studyChosen = false;
    private bool workChosen = false;

    private Color clickedColor = Color.red;
    private Color normalColor = Color.gray;

    private void Start()
    {
        studyBlock.gameObject.SetActive(false);
        workBlock.gameObject.SetActive(false);
    }

    public bool ValidateData(GameObject studyWorkBlock)
    {
        //bool error = false;
        if(!studyChosen && !workChosen)
        {
            studyWorkBlock.GetComponent<BlockScript>().errorText.text = studyWorkBlock.GetComponent<BlockScript>().errorMessage;
            return false;
        }
        else
        {
            return true;
        }
    }

    public void activateStudy()
    {
        studyChosen = !studyChosen;
        if (!studyBlock.gameObject.activeSelf)
        {
            studyBlock.gameObject.SetActive(true);
            changeContainerSize(studyBlock, true);
        }
        else
        {
            studyBlock.gameObject.SetActive(false);
            changeContainerSize(studyBlock, false);
        }
        buttonStudy.GetComponent<Image>().color = studyChosen ? clickedColor : normalColor;
        checkBoth();
    }

    public void activateWork()
    {
        workChosen = !workChosen;
        if (!workBlock.gameObject.activeSelf)
        {
            workBlock.gameObject.SetActive(true);
            changeContainerSize(workBlock, true);
        }
        else
        {
            workBlock.gameObject.SetActive(false);
            changeContainerSize(workBlock, false);
        }
        buttonWork.GetComponent<Image>().color = workChosen ? clickedColor : normalColor;
        checkBoth();
    }

    public void activateBoth()
    {
        if (studyChosen && workChosen)                  // turn both off
        {
            if(studyChosen)
            {
                activateStudy();
            }
            if(workChosen)
            {
                activateWork();
            }

            buttonStudy.GetComponent<Image>().color = normalColor;
            buttonWork.GetComponent<Image>().color = normalColor;
            buttonBoth.GetComponent<Image>().color = normalColor;
        }
        else                                           // turn both on
        {
            if (!studyChosen)
            {
                activateStudy();
            }
            if (!workChosen)
            {
                activateWork();
            }

            buttonStudy.GetComponent<Image>().color = clickedColor;
            buttonWork.GetComponent<Image>().color = clickedColor;
            buttonBoth.GetComponent<Image>().color = clickedColor;
        }
    }

    private void checkBoth()
    {
        if (studyChosen && workChosen)
        {
            buttonBoth.GetComponent<Image>().color = clickedColor;
        }
        else
        {
            buttonBoth.GetComponent<Image>().color = normalColor;
        }
    }

    private void changeContainerSize(GameObject block, bool direction)
    {
        Vector2 delta = blockContainer.GetComponent<RectTransform>().sizeDelta;
        if (direction)
        {            
            blockContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, delta.y + block.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            blockContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, delta.y - block.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
