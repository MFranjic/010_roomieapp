using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class OptionsScreen : MonoBehaviour
{
    private GameObject scrollView;
    private List<string> activeOptions;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject item = null;

    [SerializeField]
    private RectTransform content = null;

    [SerializeField]
    //private int numberOfItems = 5;

    public int itemHeight;
    public TMP_Text title;

    private int currentNumber = 0;
    private bool changeMade;

    private int maxOptions;
    private string[] itemNames;

    private void Start()
    {
        scrollView = transform.GetChild(2).gameObject;
    }

    public void InitializeOptionsScreen(string titleText, int maxItems, string[] items, List<string> currentOptions)
    {
        changeMade = false;

        itemNames = items;
        maxOptions = maxItems;
        if (currentOptions == null)
        {
            activeOptions = new List<string>();
            currentNumber = 0;
        }
        else
        {
            activeOptions = currentOptions;
            currentNumber = activeOptions.Count;
        }       
        title.text = titleText;

        FillListWithItems();
    }

    private void FillListWithItems()
    {
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Destroy(SpawnPoint.transform.GetChild(i).gameObject);
        }

        //setContent Holder Height;
        content.sizeDelta = new Vector2(0, itemNames.Length * itemHeight);

        for (int i = 0; i < itemNames.Length; i++)
        {
            //newSpawn Position
            Vector3 pos = new Vector3(SpawnPoint.localPosition.x + 5, -i * itemHeight - 5, SpawnPoint.localPosition.z);
            //instantiate item
            GameObject SpawnedItem = Instantiate(item, pos, SpawnPoint.rotation);

            //SpawnedItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
            //setParent
            SpawnedItem.transform.SetParent(SpawnPoint, false);
            //get ItemDetails Component
            ItemDetails itemDetails = SpawnedItem.GetComponent<ItemDetails>();
            //set name
            itemDetails.text.text = itemNames[i];
            
            if(activeOptions.Contains(itemNames[i]))
            {
                itemDetails.Activate();
            }
        }
    }

    public void OptionClicked()
    {
        changeMade = true;
        GameObject selectedOption = EventSystem.current.currentSelectedGameObject.gameObject;
        if (selectedOption.GetComponent<ItemDetails>().IsActive())
        {
            selectedOption.GetComponent<ItemDetails>().Deactivate();
            activeOptions.Remove(selectedOption.GetComponent<ItemDetails>().text.text);
            currentNumber--;
            Debug.Log(activeOptions.Count);
        }
        else
        {
            if (maxOptions == 1)                // da se ponaša kao obična dropdown lista
            {
                if (currentNumber == 1)
                {
                    for (int i = 0; i < itemNames.Length; i++)
                    {
                        SpawnPoint.transform.GetChild(i).GetComponent<ItemDetails>().Deactivate();                     
                    }
                    activeOptions.RemoveAt(0);
                    currentNumber--;
                }               
                selectedOption.GetComponent<ItemDetails>().Activate();
                activeOptions.Add(selectedOption.GetComponent<ItemDetails>().text.text);
                currentNumber++;
                Debug.Log(activeOptions.Count);
            }
            else
            {
                if (currentNumber < maxOptions)
                {
                    selectedOption.GetComponent<ItemDetails>().Activate();
                    activeOptions.Add(selectedOption.GetComponent<ItemDetails>().text.text);
                    currentNumber++;
                    Debug.Log(activeOptions.Count);
                }
                else
                {
                    Debug.Log("Max options reached");
                    // error - max number of options chosen
                }
            }
        }
    }

    public void SaveOptions()
    {
        if (currentNumber > 0)
        {
            GameObject.Find("SceneManager").GetComponent<OptionsManager>().SetSelectedOptions(changeMade, activeOptions);
        }
        else
        {
            Debug.Log("No options chosen");
            // error - no options chosen
        }
    }

    public void CancelOptions()
    {
        GameObject.Find("SceneManager").GetComponent<OptionsManager>().CancelOptionsPicker();
    }
}
