using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public string title;
    public int maxOptions;
    public string[] itemNames;

    public int sliderEnabledHeight;
    public int sliderDisabledHeight;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject item = null;

    private List<string> currentSelectedOptions;

    private void Start()
    {
        // TESTING
        //currentSelectedOptions = new List<string>();
        //currentSelectedOptions.Add("German");
        //
    }

    public void SetNewOptions(bool changed, List<string> newOptions)
    {
        if (changed)
        {
            currentSelectedOptions = newOptions;
            CreateOptionsGameObjects();
        }      
    }

    public List<string> GetCurrentOptions()
    {
        return currentSelectedOptions;
    }

    public void RemoveOption()
    {
        GameObject selectedOption = EventSystem.current.currentSelectedGameObject.gameObject;
        currentSelectedOptions.Remove(selectedOption.GetComponent<ChosenDetails>().text.text);
        Destroy(selectedOption.gameObject);
    }

    public void AddOptions()
    {
        GameObject.Find("SceneManager").GetComponent<OptionsManager>().ActivateOptionsPicker(title, maxOptions, itemNames, currentSelectedOptions, gameObject);
    }

    private void CreateOptionsGameObjects()
    {
        for(int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }

        SpawnPoint.GetComponent<HorizontalLayoutGroup>().enabled = false;
        for (int i = 0; i < currentSelectedOptions.Count; i++)
        {
            //newSpawn Position
            Vector3 pos = new Vector3(SpawnPoint.localPosition.x + i * 90 + 10, SpawnPoint.localPosition.y - 10, SpawnPoint.localPosition.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);

            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get ItemDetails Component
            ChosenDetails itemDetails = SpawnedItem.GetComponent<ChosenDetails>();
            //set name
            itemDetails.text.text = currentSelectedOptions[i];

            SpawnedItem.GetComponent<Button>().onClick.AddListener(RemoveOption);
        }
        SpawnPoint.GetComponent<HorizontalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
    }

    public string CreateRandomOptions(int num)
    {
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }

        currentSelectedOptions = new List<string>();
        System.Random rnd = new System.Random();
        SpawnPoint.GetComponent<HorizontalLayoutGroup>().enabled = false;
        for (int i = 0; i < num; i++)
        {
            bool found = false;
            while(!found)
            {
                string newItem = itemNames[rnd.Next(itemNames.Length)];
                if (!currentSelectedOptions.Contains(newItem))
                {
                    found = true;
                    currentSelectedOptions.Add(newItem);

                    //newSpawn Position
                    Vector3 pos = new Vector3(SpawnPoint.localPosition.x + i * 90 + 10, SpawnPoint.localPosition.y - 10, SpawnPoint.localPosition.z);
                    //instantiate item
                    GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);

                    //setParent
                    SpawnedItem.transform.SetParent(SpawnPoint, false);
                    //get ItemDetails Component
                    ChosenDetails itemDetails = SpawnedItem.GetComponent<ChosenDetails>();
                    //set name
                    itemDetails.text.text = currentSelectedOptions[i];

                    SpawnedItem.GetComponent<Button>().onClick.AddListener(RemoveOption);
                }
            }
        }
        SpawnPoint.GetComponent<HorizontalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        return GetCurrentLanguages();
    }

    private string GetCurrentLanguages()
    {
        string languages = "";
        foreach(string language in currentSelectedOptions)
        {
            languages += language + "-";
        }
        return languages;
    }

    public void EnableOptions()
    {
        RectTransform slider = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderEnabledHeight);       
        Vector3 position = new Vector3(0, 20, 0);

        slider.sizeDelta = sizeDelta;
        slider.anchoredPosition = position;

        transform.GetChild(1).gameObject.GetComponent<Slider>().interactable = true;
    }

    public void DisableOptions()
    {
        RectTransform slider = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderDisabledHeight);
        Vector3 position = new Vector3(0, 10, 0);

        slider.sizeDelta = sizeDelta;
        slider.anchoredPosition = position;

        transform.GetChild(1).gameObject.GetComponent<Slider>().interactable = false;
    }

}
