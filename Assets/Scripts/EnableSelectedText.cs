using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableSelectedText : MonoBehaviour
{
    public GameObject SelectedText;
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

        if (UnitDetails.selected == false)
        {
            SelectedText.SetActive(false);
        }
    }
}
