using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    public Button SpawnButton;

    public GameObject unitToSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton(int buttonClicked)
    {
        if (buttonClicked == 2)
        {
            unitSpawn();
        }
    }

    public void unitSpawn() 
    {
        Instantiate(unitToSpawn, new Vector3(-237f, 0.5f, -10f), Quaternion.identity);
    }
}
