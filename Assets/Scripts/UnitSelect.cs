using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    private Ray g_ray = new Ray();
    public LayerMask g_layerToHit;
    public RaycastHit g_hitObject;

    public LineLeaderOff LeaderOffScript;
    public LinePoints LinePointScript;
    public GameObject LineRender;

    public GameObject SelectedUnit;

    public GameObject hitObject;

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
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_layerToHit))
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
            this.Select();
        }
    }

    public void Select()
    {
        if (Physics.Raycast(g_ray, out g_hitObject))
        {
            // MAKE hitObject = g_hitObject.transform.gameObject; Then you can reference that to affect the right object.

            SelectedUnit = g_hitObject.transform.gameObject;

            MovementScript.enabled = true;
            LeaderOffScript.enabled = true;
            LinePointScript.enabled = true;
            MovementScript.selected = true;
            UnitSelected();
        }

    }

    public void UnitSelected()
    {

    }
}
