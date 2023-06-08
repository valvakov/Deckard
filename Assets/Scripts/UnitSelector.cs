using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    private Ray g_ray = new Ray();
    public LayerMask g_layerToHit;
    public RaycastHit g_hitObject;

    public LineLeaderOff LeaderOffScript;
    public LinePoints LinePointScript;
    public GameObject LineRender;

    public GameObject SelectedUnit;

    public FPSMovement MovementScript;

    void Start()
    {
        MovementScript.enabled = false;
        LeaderOffScript.enabled = false;
        LinePointScript.enabled = false;
    }


    void Update()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, out g_hitObject))
        {
            MouseClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Start();
        }
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }

    public void Select()
    {
        if (Physics.Raycast(g_ray, out g_hitObject))
            MovementScript.enabled = true;
            LeaderOffScript.enabled = true;
            LinePointScript.enabled = true;
            MovementScript.selected = true;
            UnitSelected();
    }

    public void UnitSelected()
    {

    }
}