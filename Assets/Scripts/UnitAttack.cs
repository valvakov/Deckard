using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public int diceRoll;
    public Text dice;
    public Text attackSuccess;

    public UnitDetails Targethp;

    public Button attackButton;

    public GameObject SelectionUnit;

    public UnitDetails UnitDetails;

    public UnitSelect UnitSelect;

    public GameObject TargetUnit;
    public UnitDetails TargetUnitDetails;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitSelect.SelectedUnit != null)
        {
            SelectionUnit = UnitSelect.SelectedUnit;
            UnitDetails = SelectionUnit.GetComponent<UnitDetails>();

            TargetUnit = UnitSelect.TargetUnit;
            TargetUnitDetails = TargetUnit.GetComponent<UnitDetails>();
        }
    }

    public void ClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
        {
            AttackBegin();
        }
    }

    public void AttackBegin()
    {
        Attack(attackSuccess);
    }

    void Attack(Text attackSuccess)
    {
        UnitSelect.SelectedUnit.GetComponent<UnitDetails>();
        diceRoll = Random.Range(1, 7);
        dice.text = diceRoll.ToString();

        if (diceRoll > UnitDetails.hit)
        {
            attackSuccess.text = "Attack hit";
            TargetUnitDetails.hp -=1;
            UnitDetails.fatigued = true;
        }
        if (diceRoll == UnitDetails.hit)
        {
            attackSuccess.text = "Attack hit";
            TargetUnitDetails.hp -=1;
            UnitDetails.fatigued = true;
        }
        if (diceRoll < UnitDetails.hit)
        {
            attackSuccess.text = "Attack Miss";
            UnitDetails.fatigued = true;
        }
    }
}
