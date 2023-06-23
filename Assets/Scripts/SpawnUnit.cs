using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject unitToSpawn2;
    public UnitSelect unitSelect;
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

        if (buttonClicked == 3)
        {
            Spawn2();
        }
    }

    public void Spawn()
    {
        unitSelect.SelectedUnit = null;
        Instantiate(unitToSpawn, new Vector3(-240f, 0.5f, -10f), Quaternion.identity);
    }

    public void Spawn2()
    {
        unitSelect.SelectedUnit = null;
        Instantiate(unitToSpawn2, new Vector3(-240f, 0.5f, 9f), Quaternion.identity);
    }
}
