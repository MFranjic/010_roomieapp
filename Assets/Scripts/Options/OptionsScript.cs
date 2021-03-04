using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public int index;
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

    public Button ButtonChange;
    public Slider Slider;
    
    private List<string> currentSelectedOptions;

    private System.Random rnd;

    public bool editable = false;
    public bool edited = false;

    private List<string> oldSelectedOptions;
    private float oldSliderValue;

    private void Start()
    {
        rnd = new System.Random();
        Slider.onValueChanged.AddListener(delegate { OnSliderChange(); });
    }

    private void OnSliderChange()
    {
        edited = true;
    }

    public void RefreshEdit()
    {
        edited = false;
    }

    // LOADING
    public void LoadAlgoData(StudentAlgo user)
    {
        string data = user.GetProperty(index);
        int sliderValue = user.GetSliderValue(index);
        SetOptionsFromDataString(data);
        SetSliderValue(sliderValue);
        InitializeOldValues();
    }

    // LOADING
    private void InitializeOldValues()
    {
        oldSelectedOptions = new List<string>();
        foreach(string option in currentSelectedOptions)
        {
            oldSelectedOptions.Add(option);
        }
        oldSliderValue = Slider.value;
    }

    // LOADING
    private void SetSliderValue(int sliderValue)
    {
        Slider.value = sliderValue;
    }

    // LOADING
    private void SetOptionsFromDataString(string data)
    {
        currentSelectedOptions = new List<string>();

        if (!data.Equals(""))
        {
            string[] currentData = data.Split('-');
            for (int i = 0; i < currentData.Length; i++)
            {
                currentSelectedOptions.Add(itemNames[int.Parse(currentData[i])]);
            }            
        }      
    }

    public void CreateOptions()
    {
        CreateOptionsGameObjects();
    }

    // SAVING
    public StudentAlgo SetAlgoData(StudentAlgo user)
    {
        if (edited)
        {
            string newData = FetchDataStringFromOptions();
            int sliderValue = FetchSliderValue();
            user.SetProperty(index, newData, sliderValue);
            InitializeOldValues();
        }
        return user;
    }

    // SAVING
    private int FetchSliderValue()
    {
        int sliderValue = (int)Slider.value;
        return sliderValue;
    }

    // SAVING
    private string FetchDataStringFromOptions()
    {
        string newData = "";
        if (currentSelectedOptions != null)
        {
            int limit = currentSelectedOptions.Count;
            for (int i = 0; i < itemNames.Length; i++)
            {
                if (currentSelectedOptions.Contains(itemNames[i]))
                {
                    newData += i;
                    limit--;
                    if (limit > 0)
                    {
                        newData += "-";
                    }
                }
            }
        }
        return newData;
    }

    // CANCELING
    public void RollBackChanges()
    {
        if (edited)
        {
            Slider.value = oldSliderValue;
            currentSelectedOptions = oldSelectedOptions;
            CreateOptionsGameObjects();
            InitializeOldValues();
        }
    }

    public void SetNewOptions(bool changed, List<string> newOptions)
    {
        if (changed)
        {
            edited = true;
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
        if (editable)
        {
            edited = true;
            GameObject selectedOption = EventSystem.current.currentSelectedGameObject.gameObject;
            currentSelectedOptions.Remove(selectedOption.GetComponent<ChosenDetails>().text.text);
            Destroy(selectedOption.gameObject);
        }
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

            //get ItemDetails Component
            ChosenDetails itemDetails = SpawnedItem.GetComponent<ChosenDetails>();
            //set name
            itemDetails.text.text = currentSelectedOptions[i];

            SpawnedItem.GetComponent<Button>().onClick.AddListener(RemoveOption);
        }

        Canvas.ForceUpdateCanvases();
    }

    public string CreateRandomOptions()
    {
        string data = "";

        edited = true;

        // DESTROY current
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }

        GameObject SpawnedEmpty = Instantiate(empty, SpawnPoint.localPosition, SpawnPoint.rotation);
        SpawnedEmpty.transform.SetParent(SpawnPoint, false);
        SpawnedEmpty.SetActive(false);

        currentSelectedOptions = new List<string>();
        
        int num = rnd.Next(maxOptions) + 1;

        for (int i = 0; i < num; i++)
        {
            bool found = false;
            while(!found)
            {
                int newItemIndex = rnd.Next(itemNames.Length);
                data += newItemIndex;
                if (i < num - 1)
                {
                    data += "-";
                }
                string newItem = itemNames[newItemIndex];
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

        return data;
    }

    public string SetStringData(string indexNumbers)
    {
        editable = true;
        currentSelectedOptions = new List<string>();
        string data = "";
        string[] dataList = indexNumbers.Split('-');
        for(int i = 0; i < dataList.Length; i++)
        {
            string targetData = itemNames[int.Parse(dataList[i])];
            currentSelectedOptions.Add(targetData);
            data += targetData;
            if (i < dataList.Length - 1)
            {
                data += ", ";
            }
        }
        CreateOptionsGameObjects();
        return data;
    }

    public string GetStringData()
    {
        return FetchDataStringFromOptions();
    }

    public void EnableOptions()
    {
        editable = true;

        //RectTransform slider = Slider.gameObject.GetComponent<RectTransform>();
        //Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderEnabledHeight);       
        //Vector3 position = new Vector3(0, 20, 0);

        //slider.sizeDelta = sizeDelta;
        //slider.anchoredPosition = position;

        Slider.gameObject.GetComponent<Slider>().interactable = true;
        ButtonChange.gameObject.SetActive(true);
    }

    public void DisableOptions()
    {
        editable = false;

        //RectTransform slider = Slider.gameObject.GetComponent<RectTransform>();
        //Vector2 sizeDelta = new Vector2(slider.sizeDelta.x, sliderDisabledHeight);
        //Vector3 position = new Vector3(0, 10, 0);

        //slider.sizeDelta = sizeDelta;
        //slider.anchoredPosition = position;

        Slider.gameObject.GetComponent<Slider>().interactable = false;
        ButtonChange.gameObject.SetActive(false);
    }
}
