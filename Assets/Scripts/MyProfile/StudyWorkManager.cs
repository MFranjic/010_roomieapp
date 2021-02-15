using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StudyWorkManager : MonoBehaviour
{
    public GameObject studyBlock;
    public GameObject workBlock;

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

    public bool ValidateData()
    {

        return true;
    }

    public void activateStudy()
    {
        studyChosen = !studyChosen;
        studyBlock.gameObject.SetActive(studyChosen);

        buttonStudy.GetComponent<Image>().color = studyChosen ? clickedColor : normalColor;
        checkBoth();
    }

    public void activateWork()
    {
        workChosen = !workChosen;
        workBlock.gameObject.SetActive(workChosen);

        buttonWork.GetComponent<Image>().color = workChosen ? clickedColor : normalColor;
        checkBoth();
    }

    public void activateBoth()
    {
        if (studyChosen && workChosen)
        {
            studyChosen = false;
            workChosen = false;
            studyBlock.gameObject.SetActive(false);
            workBlock.gameObject.SetActive(false);

            buttonStudy.GetComponent<Image>().color = normalColor;
            buttonWork.GetComponent<Image>().color = normalColor;
            buttonBoth.GetComponent<Image>().color = normalColor;
        }
        else
        {
            studyChosen = true;
            workChosen = true;
            studyBlock.gameObject.SetActive(true);
            workBlock.gameObject.SetActive(true);

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


}
