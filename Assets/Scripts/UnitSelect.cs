using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    private Ray g_ray = new Ray();
    public LayerMask g_layerToHit;
    public LayerMask g_enemyLayer;
    public RaycastHit g_hitObject;

    public LineLeaderOff LeaderOffScript;
    public LinePoints LinePointScript;
    public GameObject LineRender;
    public GameObject GameManager;

    public GameObject SelectedUnit;
    public GameObject TargetUnit;

    public UnitDetails UnitDetails;

    public GameObject hitObject;

    public FPSMovement MovementScript;

    public LinePoints LinePoints;

    public Text SelectedText;

    void Start()
    {
        MovementScript.attackButton.gameObject.SetActive(false);
        if (SelectedUnit != null)
        {
            UnitDetails.attacking = false;
            SelectedUnit.GetComponent<FPSMovement>().enabled = false;
            // in here!
        }


        LineRender.SetActive(false);
        GameManager.GetComponent<LineLeaderOff>().enabled = false;
        SelectedUnit = null;
        TargetUnit = null;
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

        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_enemyLayer))
        {
            AttackCheck();
        }

        if (SelectedUnit != null)
        {
            UnitDetails = SelectedUnit.GetComponent<UnitDetails>();
            if (UnitDetails.attacking == false)
            {
                if (TargetUnit != null)
                {
                    TargetUnit = null;
                }
            }
        }
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            check();
        }
    }

    public void check()
    {
        if (SelectedUnit == null)
        {
            Select();
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
        LineRender?.SetActive(true);
        MovementScript.attackButton.gameObject.SetActive(false);
        GameManager.GetComponent<AttackingRange>().enabled = false;
        SelectedUnit.GetComponent<FPSMovement>().enabled = true;
        GameManager.GetComponent<LineLeaderOff>().enabled = true;
    }

    public void AttackMode()
    {

        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_layerToHit))
        {
            AttackCheck();
        }
        Debug.Log("Attacking");
    }

    public void AttackCheck()
    {
        if (UnitDetails.attacking == true)

            if (Input.GetMouseButtonDown(0))
            {
                AttackSuccess();
            }
    }

    public void AttackSuccess()
    {
        if (Physics.Raycast(g_ray, out g_hitObject))
        {
            TargetUnit = g_hitObject.transform.gameObject;
        }
    }
}

