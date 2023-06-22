using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
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
            Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(unitToSpawn, new Vector3(-240f, 0.5f, -10f), Quaternion.identity);
    }
}
