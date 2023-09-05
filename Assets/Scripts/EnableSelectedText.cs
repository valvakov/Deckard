using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableSelectedText : MonoBehaviour
{
    public GameObject SelectedText;
    public GameObject AttackingText;
    public GameObject TargetedText;
    public GameObject FatiguedText;
    public GameObject EncumberedText;
    public UnitDetails UnitDetails;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitDetails.selected == true)
        {
            SelectedText.SetActive(true);
        }
        if (UnitDetails.attacking == true)
        {
            AttackingText.SetActive(true);
        }
        if (UnitDetails.fatigued == true)
        {
            FatiguedText.SetActive(true);
        }
        if (UnitDetails.encumbered == true)
        {
            EncumberedText.SetActive(true);
        }
        if (UnitDetails.targeted == true)
        {
            TargetedText.SetActive(true);
        }

        if (UnitDetails.selected == false)
        {
            SelectedText.SetActive(false);
        }
        if (UnitDetails.attacking == false)
        {
            AttackingText.SetActive(false);
        }
        if (UnitDetails.fatigued == false)
        {
            FatiguedText.SetActive(false);
        }
        if (UnitDetails.encumbered == false)
        {
            EncumberedText.SetActive(false);
        }
        if (UnitDetails.targeted == false)
        {
            TargetedText.SetActive(false);
        }
    }
}
