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

    public GameObject LineLeader;

    public GameObject LineRender;

    public SwitchCamera SwitchCamera;

    public GameObject SelectedUnit;

    public GameObject AttackResult;

    public GameObject DiceResult;

    public GameObject AttackTutorialCam1;
    public GameObject AttackTutorialCam2;

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

        if (UnitSelect.SelectedUnit == null)
        {
            LineLeader.GetComponent<MouseFollow>().enabled = true;
        }

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
                AttackResult.gameObject.SetActive(true);
                DiceResult.gameObject.SetActive(true);
                AttackTutorialCam1.gameObject.SetActive(true);
                AttackTutorialCam2.gameObject.SetActive(true);
            }

            if (UnitDetails.attacking == false)
            {
                FPSMovement.attackButton.gameObject.SetActive(false);
                AttackResult.gameObject.SetActive(false);
                DiceResult.gameObject.SetActive(false);
                AttackTutorialCam1.gameObject.SetActive(false);
                AttackTutorialCam2.gameObject.SetActive(false);
            }

        }
     }
}

