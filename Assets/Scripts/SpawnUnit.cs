using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject unitToSpawn2;
    public UnitSelect unitSelect;

    public ActionPoints ActionPoints;

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
            if (ActionPoints.actionPoints >= 3)
            {
                Spawn();
            }
        }

        if (buttonClicked == 3)
        {
            if (ActionPoints.actionPoints >= 3)
            {
                Spawn2();
            }
        }
    }

    public void Spawn()
    {
        ActionPoints.actionPoints -= 3;
        unitSelect.SelectedUnit = null;
        Instantiate(unitToSpawn, new Vector3(-240f, 0.5f, -10f), Quaternion.identity);
    }

    public void Spawn2()
    {
        ActionPoints.actionPoints -= 3;
        unitSelect.SelectedUnit = null;
        unitToSpawn2.transform.Rotate(0f, 180f, 0f);
        Instantiate(unitToSpawn2, new Vector3(-240f, 0.5f, 9f), Quaternion.identity);
    }
}
