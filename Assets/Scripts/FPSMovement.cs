using System.Xml;
using UnityEngine;
using UnityEngine.UI;

// THIS PLAYER MOVE CLASS WILL ALLOW THE GAMEOBJECT TO MOVE BASED ON CHARACTERCONTROLLER

public class FPSMovement : MonoBehaviour
{
    Vector3 newPosition;
    public Transform target;
    public ActionPoints ActionPointScript;

    public int hp;
    public int mv;
    public int range;
    public int block;
    public int hit;

    private int diceRoll;
    public Text dice;
    public Text attackSuccess;

    public Button attackButton;

    void Start()
    {
        newPosition = transform.position;
    }


    void Update()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Click to move
                ActionPointScript.actionPoints -= 1; //Deducts AP after moving
 
                if (Physics.Raycast(ray, out hit))
                {
                    newPosition = hit.point;
                    transform.position = newPosition;
                }

            }
        }
    }

    public void ClickButton(int buttonClicked)
    {

        if (buttonClicked == 1)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Attack(attackSuccess);
    }

    void Attack(Text attackSuccess)
    {
        Debug.Log("Button pressed");
        diceRoll = Random.Range(1, 7);
        dice.text = diceRoll.ToString();

        //if (diceRoll < hit)
        {
            attackSuccess.text += "Attack hit";
        }

       // if (diceRoll = hit)
        {
            attackSuccess.text += "Attack hit";
        }

       // if (diceRoll > hit)
        {
            attackSuccess.text += "Attack miss";
        }
    }

}