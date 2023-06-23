using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera1Move;
    public GameObject Camera2Move;
    public GameObject SelectedCamera;

    public ActionPoints ActionPoints;

    public UnitSelect UnitSelect;

    public List<GameObject> Player1; 
    public List<GameObject> Player2;

    void Start()
    {
        SelectedCamera = Camera1;
    }

    // Update is called once per frame
    void Update()
    {
        ActionPoints = SelectedCamera.GetComponent<ActionPoints>();
        UnitSelect = SelectedCamera.GetComponent<UnitSelect>();

        if (Camera1.activeInHierarchy == false)
        {
            SelectedCamera = Camera2;
        }

        if (Camera2.activeInHierarchy == false)
        {
            SelectedCamera = Camera1;
        }
    }

    public void CLickButton(int buttonClicked)
    {
        if (buttonClicked == 3)
        {
            foreach (GameObject Unit1 in Player1)
            {
                Unit1.GetComponent<UnitDetails>().encumbered = false;
                Debug.Log("I am working");
            }
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera1Move.SetActive(false);
            Camera2Move.SetActive(true);
            UnitSelect.SelectedUnit = null;
        }

        if (buttonClicked == 4)
        {
            foreach (GameObject Unit2 in Player2)
            {
                Unit2.GetComponent<UnitDetails>().encumbered = false;
                Debug.Log("I am working");
            }
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera1Move.SetActive(true);
            Camera2Move.SetActive(false);
            UnitSelect.SelectedUnit = null;
        }
    }
}
