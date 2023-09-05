using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    private Ray g_ray = new Ray();
    public LayerMask g_friendlyLayer;
    public LayerMask g_enemyLayer;
    public RaycastHit g_hitObject;
    public GameObject hitObject;

    public LineLeaderOff LeaderOffScript;
    public LinePoints LinePointScript;
    public GameObject LineRender;
    public GameObject GameManager;

    public GameObject SelectedUnit;
    public GameObject TargetUnit;

    public UnitDetails UnitDetails;
    public FPSMovement MovementScript;

    public UnitDetails TargetUnitDetails;

    public LinePoints LinePoints;

    public Text AttackTutorial;

    public Text SelectedText;

    public GameObject DiceResult;
    public GameObject AttackResult;

    void Start()
    {
        MovementScript.attackButton.gameObject.SetActive(false);
        if (SelectedUnit != null) //used to avoid nullexception
        {
            UnitDetails.attacking = false;
            SelectedUnit.GetComponent<FPSMovement>().enabled = false;
            UnitDetails.selected = true;
            // in here!
        }

        if (TargetUnit != null)
        {
            TargetUnitDetails.targeted = false;
            TargetUnitDetails = null;
        }
        LineRender.SetActive(false);
        GameManager.GetComponent<LineLeaderOff>().enabled = false;
        SelectedUnit = null;
        TargetUnit = null;
        AttackTutorial.enabled = false;
    }


    void Update()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_friendlyLayer))
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

        if (SelectedUnit != null) //used to avoid nullexception
        {
            UnitDetails = SelectedUnit.GetComponent<UnitDetails>();
            UnitDetails.selected = true;
            AttackTutorial.enabled = true; 
            if (UnitDetails.attacking == false)
            {
                if (TargetUnit != null) //used to avoid nullexception
                {
                    TargetUnit = null;
                }
            }
        }

        if (SelectedUnit == null)
        {
            DiceResult.gameObject.SetActive(false);
            AttackResult.gameObject.SetActive(false);
        }

        if (TargetUnit != null)
        {
            TargetUnitDetails = TargetUnit.GetComponent<UnitDetails>();
            TargetUnitDetails.targeted = true;
        }
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Check();
        }
    }

    public void Check()
    {
        if (SelectedUnit == null) //used to stop selecting another unit whilst one is already selected
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
        AttackTutorial.enabled = true;
    }

    public void AttackMode()
    {

        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_friendlyLayer))
        {
            AttackCheck();
        }
        Debug.Log("Attacking");
    }

    public void AttackCheck()
    {
        if (SelectedUnit != null) //used to avoid nullexception
        {
            if (UnitDetails.attacking == true)

                if (Input.GetMouseButtonDown(0))
                {
                    AttackSuccess();
                }
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

