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
    public GameObject GameManager;
    public Material Material1;
    public Material Material2;

    public GameObject SelectedUnit;

    public GameObject hitObject;

    public FPSMovement MovementScript;

    void Start()
    {
        SelectedUnit.GetComponent<MeshRenderer>().material = Material2;
        SelectedUnit.GetComponent<FPSMovement>().enabled = false;
        LineRender.SetActive(false);
        GameManager.GetComponent<LineLeaderOff>().enabled = false;
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

            UnitSelected();
        }

    }

    public void UnitSelected()
    {
        SelectedUnit.GetComponent<MeshRenderer>().material = Material1;
        SelectedUnit.GetComponent<FPSMovement>().enabled = true;
        GameManager.GetComponent<LineLeaderOff>().enabled = true;
        LineRender?.SetActive(true);
    }
}
