﻿using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// THIS PLAYER MOVE CLASS WILL ALLOW THE GAMEOBJECT TO MOVE BASED ON CHARACTERCONTROLLER

public class FPSMovement : MonoBehaviour
{
    Vector3 newPosition;
    public Transform target;
    public ActionPoints ActionPointScript;
    public UnitSelect SelectScript;

    private Ray g_ray = new Ray();
    public LayerMask g_layerToHit;
    private RaycastHit g_hitObject;

    public int hp;
    public int mv;
    public int range;
    public int block;
    public int hit;

    public bool selected;
    public bool encumbered;

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
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, Mathf.Infinity, g_layerToHit))
        {
            Movement();
        }
    }

    public void Movement()
    {
        {
        if (encumbered == true)
            {
                Encumberedtrue();
            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Click to move
                ActionPointScript.actionPoints -= 1; //Deducts AP after moving
                encumbered = true;

                if (Physics.Raycast(ray, out hit))
                {
                    newPosition = hit.point;
                    transform.position = newPosition;
                }

            }
        }
    }

    public void Encumberedtrue()
    {
        mv = 0;
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