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

    [SerializeField]
    private GameObject empty = null;

    private List<string> currentSelectedOptions;

    private void Start()
    {
        // TESTING
        currentSelectedOptions = new List<string>();
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

        // DESTROY current
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);        
        }

        GameObject SpawnedEmpty = Instantiate(empty, SpawnPoint.localPosition, SpawnPoint.rotation);
        SpawnedEmpty.transform.SetParent(SpawnPoint, false);
        SpawnedEmpty.SetActive(false);

        for (int i = 0; i < currentSelectedOptions.Count; i++)
        {
            GameObject SpawnedItem = Instantiate(item, SpawnPoint.localPosition, SpawnPoint.rotation);

            SpawnedItem.transform.SetParent(SpawnPoint, false);

            Debug.Log(SpawnedItem.GetComponent<RectTransform>().sizeDelta.x);

            //get ItemDetails Component
            ChosenDetails itemDetails = SpawnedItem.GetComponent<ChosenDetails>();
            //set name
            itemDetails.text.text = currentSelectedOptions[i];

            SpawnedItem.GetComponent<Button>().onClick.AddListener(RemoveOption);
        }

        Canvas.ForceUpdateCanvases();
    }

    public string CreateRandomOptions(int num)
    {
        // DESTROY current
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }

        GameObject SpawnedEmpty = Instantiate(empty, SpawnPoint.localPosition, SpawnPoint.rotation);
        SpawnedEmpty.transform.SetParent(SpawnPoint, false);
        SpawnedEmpty.SetActive(false);

        currentSelectedOptions = new List<string>();
        System.Random rnd = new System.Random();

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

                    GameObject SpawnedItem = Instantiate(item, SpawnPoint.localPosition, SpawnPoint.rotation);

                    SpawnedItem.transform.SetParent(SpawnPoint, false);

                    //get ItemDetails Component
                    ChosenDetails itemDetails = SpawnedItem.GetComponent<ChosenDetails>();
                    //set name
                    itemDetails.text.text = currentSelectedOptions[i];

                    SpawnedItem.GetComponent<Button>().onClick.AddListener(RemoveOption);
                }
            }
        }

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
