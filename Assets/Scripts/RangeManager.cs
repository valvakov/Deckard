using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeManager : MonoBehaviour
{
    public GameObject GameManager;

    public UnitDetails UnitDetails;

    public UnitSelect UnitSelect;

    public FPSMovement FPSMovement;

    public GameObject Camera;

    public GameObject LineRender;

    public SwitchCamera SwitchCamera;

    public GameObject SelectedUnit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera = SwitchCamera.SelectedCamera;
        SelectedUnit = UnitSelect.SelectedUnit;
        UnitSelect = Camera.GetComponent<UnitSelect>();
        FPSMovement = Camera.GetComponent<FPSMovement>();

        if (UnitSelect.SelectedUnit != null)
        {
            SelectedUnit.GetComponent<UnitDetails>();

            UnitDetails = UnitSelect.SelectedUnit.GetComponent<UnitDetails>();
            if (UnitDetails.fatigued == false)
            {

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
}

