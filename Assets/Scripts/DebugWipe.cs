using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DebugWipe : MonoBehaviour
{
    public GameObject gameManager;

    public Button WipeButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton(int buttonClicked)
    {
        if (buttonClicked == 5)
        {
            DebugGo();
        }
    }

    public void DebugGo()
    {
        gameManager.GetComponent<LineLeaderOff>().enabled = false;
        gameManager.GetComponent<AttackingRange>().enabled = false;
        gameManager.GetComponent<RangeManager>().enabled = false;
        gameManager.GetComponent<SwitchCamera>().enabled = false;
        gameManager.GetComponent<LinePoints>().enabled = false;
        gameManager.GetComponent<LineLeaderOff>().enabled = true;
        gameManager.GetComponent<AttackingRange>().enabled = true;
        gameManager.GetComponent<RangeManager>().enabled = true;
        gameManager.GetComponent<SwitchCamera>().enabled = true;
        gameManager.GetComponent<LinePoints>().enabled = true;
        gameManager.GetComponent<LineLeaderOff>().enabled = false;
        gameManager.GetComponent<AttackingRange>().enabled = false;
    }
}
