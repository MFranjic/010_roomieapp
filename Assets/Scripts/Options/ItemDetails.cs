using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetails : MonoBehaviour
{
    public TMP_Text text;

    private bool active = false;
    private Color basicColor = Color.gray;
    private Color activeColor = Color.green;

    private void Start()
    {
        //basicColor = GetComponent<Button>().GetComponent<Image>().color;
        if(!active)
            GetComponent<Button>().GetComponent<Image>().color = basicColor;
        else
            GetComponent<Button>().GetComponent<Image>().color = activeColor;
    }

    public bool IsActive()
    {
        return active;
    }

    public void Activate()
    {
        active = true;
        GetComponent<Button>().GetComponent<Image>().color = activeColor;
    }

    public void Deactivate()
    {
        active = false;
        GetComponent<Button>().GetComponent<Image>().color = basicColor;
    }

    public void ClickOption()
    {
        GameObject.Find("SceneManager").GetComponent<OptionsManager>().OptionClicked();
    }
}
