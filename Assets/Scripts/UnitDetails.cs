using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDetails : MonoBehaviour
{
    public ActionPoints ActionPointScript;

    public int hp;
    public int mv;
    public int range;
    public int block;
    public int hit;

    public bool selected;
    public bool encumbered;
    public bool fatigued;
    public bool attacking;

    private int diceRoll;
    public Text dice;
    public Text attackSuccess;
    //public GameObject Thisunit;

    public Button attackButton;

    void Start()
    {

    }


    void Update()
    {
        if (hp == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
