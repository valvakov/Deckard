using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPoints : MonoBehaviour
{
    public int actionPoints;
    public FPSMovement MovementScript;
    public Text AP;

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
        AP.text = actionPoints.ToString();
        if (actionPoints == 0)
            MovementScript.enabled = false;
    }
}
