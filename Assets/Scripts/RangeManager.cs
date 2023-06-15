using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : MonoBehaviour
{
    public GameObject GameManager;

    public UnitDetails UnitDetails;

    public UnitSelect UnitSelect;

    public FPSMovement FPSMovement;

    public GameObject Camera;

    public GameObject LineRender;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitDetails = UnitSelect.SelectedUnit.GetComponent<UnitDetails>();

        if (UnitSelect.SelectedUnit != null)
        {
            if (Input.GetKeyDown("space"))
            {
                UnitDetails.attacking = true;
                UnitSelect.SelectedUnit.GetComponent<FPSMovement>().enabled = false;
                GameManager.GetComponent<AttackingRange>().enabled = true;
                GameManager.GetComponent<LineLeaderOff>().enabled = false;
            }

        }

        if (UnitDetails.attacking == true)
        {
            FPSMovement.attackButton.gameObject.SetActive(true);
        }

        if (UnitDetails.attacking == false)
        {
            FPSMovement.attackButton.gameObject.SetActive(false);
        }
    }
}
