using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera2Move;
    public GameObject CameraMove;
    public GameObject SelectedCamera;

    public ActionPoints ActionPoints;

    void Start()
    {
        SelectedCamera = Camera1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            Camera2Move.SetActive(true);
            CameraMove.SetActive(false);
            SelectedCamera = Camera2;
        }

        if (Input.GetKeyDown("`"))
        {
            Camera1.SetActive(true);
            Camera2.SetActive(false);
            Camera2Move.SetActive(false);
            CameraMove.SetActive(true);
            SelectedCamera = Camera1;
        }
    }
}
