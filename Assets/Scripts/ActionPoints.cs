using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionPoints : MonoBehaviour
{
    public int actionPoints;
    public FPSMovement MovementScript;
    public Text AP;
    public UnitSelect UnitSelect;

    void Start()
    {
        TurnStart();
    }

    void TurnStart()
    {
        actionPoints = 6;
    }

    void Update()
    {
        MovementScript = UnitSelect.SelectedUnit.GetComponent<FPSMovement>();
        AP.text = actionPoints.ToString();
        if (actionPoints == 0)
            UnitSelect.SelectedUnit.GetComponent<FPSMovement>().enabled = false;
    }
}
