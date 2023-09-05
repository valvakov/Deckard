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

    public Text AttackResult1;
    public Text AttackResult2;

    public Text DiceResult1;
    public Text DiceResult2;


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
                    AttackTutorialCam1.gameObject.SetActive(true);
                    AttackTutorialCam2.gameObject.SetActive(true);
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
                AttackResult1.gameObject.SetActive(true);
                DiceResult1.gameObject.SetActive(true);
                AttackResult2.gameObject.SetActive(true);
                DiceResult2.gameObject.SetActive(true);
            }

            if (UnitDetails.attacking == false)
            {
                AttackResult1.text = "";
                DiceResult1.text = "";
                AttackResult2.text = "";
                DiceResult2.text = "";
            }

        }
     }
}

