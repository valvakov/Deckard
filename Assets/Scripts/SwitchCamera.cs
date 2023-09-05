using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera1Move;
    public GameObject Camera2Move;
    public GameObject SelectedCamera;

    public RangeManager RangeManager;

    public ActionPoints ActionPoints;

    public UnitSelect UnitSelect;

    public UnitAttack UnitAttack;

    public LinePoints LinePoints;

    public List<GameObject> Player1; 

    public List<GameObject> Player2;

    public GameObject LineRender;

    public Text SelectTutorial1;
    public Text SelectTutorial2;

    void Start()
    {
        SelectedCamera = Camera1;
    }

    // Update is called once per frame
    void Update()
    {
        ActionPoints = SelectedCamera.GetComponent<ActionPoints>();
        UnitSelect = SelectedCamera.GetComponent<UnitSelect>();
        UnitAttack = SelectedCamera.GetComponent<UnitAttack>();

        if (Camera1.activeInHierarchy == false)
        {
            SelectedCamera = Camera2;
        }

        if (Camera2.activeInHierarchy == false)
        {
            SelectedCamera = Camera1;
        }

        if(ActionPoints.actionPoints == 0)
        {
            SelectedCamera.GetComponent<UnitAttack>().enabled = false;
            UnitAttack.attackButton.enabled = false;
        }

        if(ActionPoints.actionPoints == 6)
        {
            SelectedCamera.GetComponent<UnitAttack>().enabled = true;
            UnitAttack.attackButton.enabled = true;
        }

        if(UnitSelect.SelectedUnit == null)
        {
            foreach (GameObject Unit1 in Player1)
            {
                Unit1.GetComponent<UnitDetails>().selected = false;
            }
            foreach (GameObject Unit2 in Player2)
            {
                Unit2.GetComponent<UnitDetails>().selected = false;
            }
        }
        if(UnitSelect.TargetUnit == null)
        {
            foreach (GameObject Unit1 in Player1)
            {
                Unit1.GetComponent<UnitDetails>().targeted = false;
            }
            foreach (GameObject Unit2 in Player2)
            {
                Unit2.GetComponent<UnitDetails>().targeted = false;
            }
        }
    }

    public void CLickButton(int buttonClicked)
    {
        if (buttonClicked == 3)
        {
            SelectedCamera.GetComponent<UnitAttack>().enabled = true;
            foreach (GameObject Unit1 in Player1)
            {
                Unit1.GetComponent<UnitDetails>().encumbered = false;
                Unit1.GetComponent<UnitDetails>().fatigued = false;
                Unit1.GetComponent<UnitDetails>().selected = false;
            }
            RangeManager.AttackTutorialCam1.SetActive(false);
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera1Move.SetActive(false);
            Camera2Move.SetActive(true);
            UnitSelect.SelectedUnit = null;
            ActionPoints.actionPoints = 6;
            LineRender.gameObject.SetActive(false);
            SelectTutorial1.text = "";
        }

        if (buttonClicked == 4)
        {
            SelectedCamera.GetComponent<UnitAttack>().enabled = true;
            foreach (GameObject Unit2 in Player2)
            {
                Unit2.GetComponent<UnitDetails>().encumbered = false;
                Unit2.GetComponent<UnitDetails>().fatigued = false;
                Unit2.GetComponent<UnitDetails>().selected = false;
            }
            RangeManager.AttackTutorialCam2.SetActive(false);
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera1Move.SetActive(true);
            Camera2Move.SetActive(false);
            UnitSelect.SelectedUnit = null;
            ActionPoints.actionPoints = 6;
            LineRender.gameObject.SetActive(false);
            SelectTutorial2.text = "";
        }
    }
}
