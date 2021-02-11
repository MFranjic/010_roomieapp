using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public GameObject selectedOption;
    public GameObject panelOptionsPicker;

    public void SetSelectedOptions(bool changed, List<string> options)
    {
        selectedOption.GetComponent<OptionsScript>().SetNewOptions(changed, options);
        panelOptionsPicker.SetActive(false);
    }

    public void OptionClicked()
    {
        panelOptionsPicker.GetComponent<OptionsScreen>().OptionClicked();
    }

    public void CancelOptionsPicker()
    {
        panelOptionsPicker.SetActive(false);
    }

    public void ActivateOptionsPicker(string titleText, int maxItems, string[] items, List<string> currentOptions, GameObject optionPanel)
    {
        selectedOption = optionPanel;
        panelOptionsPicker.SetActive(true);
        panelOptionsPicker.GetComponent<OptionsScreen>().InitializeOptionsScreen(titleText, maxItems, items, currentOptions);
    }
}
