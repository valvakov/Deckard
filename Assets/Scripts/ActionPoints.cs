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

    public SwitchCamera SwitchCamera;

    public GameObject Camera1;
    public GameObject Camera2;

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
        if (UnitSelect.SelectedUnit != null)
        {
            MovementScript = UnitSelect.SelectedUnit.GetComponent<FPSMovement>();
        }

        AP.text = actionPoints.ToString();
        if (actionPoints == 0)
        {
          UnitSelect.SelectedUnit.GetComponent<FPSMovement>().enabled = false;
        }

        if (Input.GetKeyDown("escape"))
        {
            TurnStart();
        }
        if (Input.GetKeyDown("`"))
        {
            TurnStart();
        }
    }
}
