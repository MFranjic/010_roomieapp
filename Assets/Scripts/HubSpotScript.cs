using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HubSpot.NET.Core;
using HubSpot.NET.Api.Contact.Dto;
using UnityEngine.UI;

public class HubSpotScript : MonoBehaviour
{
    public InputField usernameIF;
    public InputField passwordIF;

    private string API_key = "ee3c5e2e-2165-45b4-865e-8368f2389c55";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {
        /*var api = new HubSpotApi(API_key);

        // Create a contact
        var contact = api.Contact.Create(new ContactHubSpotModel()
        {
            Email = "john@squaredup.com",
            FirstName = "John",
            LastName = "Smith",
            Phone = "00000 000000",
            Company = "Squared Up Ltd."
        });*/

        Debug.Log(usernameIF.text);
        Debug.Log(passwordIF.text);

    }
}
