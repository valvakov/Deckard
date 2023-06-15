using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAttack : MonoBehaviour
{
    public int diceRoll;
    public Text dice;
    public Text attackSuccess;

    public int Targethp;

    public Button attackButton;

    public GameObject SelectionUnit;

    public UnitDetails UnitDetails;

    public UnitSelect UnitSelect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

        if (diceRoll < UnitDetails.hit)
        {
            attackSuccess.text = "Attack hit";
            UnitDetails.hp =- 1;
        }
        if (diceRoll == UnitDetails.hit)
        {
            attackSuccess.text = "Attack hit";
            UnitDetails.hp = -1;
        }
        if (diceRoll > UnitDetails.hit)
        {
            attackSuccess.text = "Attack Miss";
        }
    }
}
