using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUserInitialization : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<DatabaseManager>().FindDatabase();
    }
}
