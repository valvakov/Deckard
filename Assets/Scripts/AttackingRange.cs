using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingRange : MonoBehaviour
{
    public object mouseFollow;
    public Transform mouseLeader;
    public Transform player;
    public FPSMovement movementScript;
    public MouseFollow mouseScript;

    public UnitDetails UnitDetails;

    public SwitchCamera CameraSelect;

    public GameObject SelectedCamera;

    public UnitSelect UnitSelectScript;

    void Start()
    {

    }
    void Update()
    {
        SelectedCamera = CameraSelect.SelectedCamera;
        if (UnitSelectScript != null)
        {
            UnitSelectScript = SelectedCamera.GetComponent<UnitSelect>();
            UnitDetails = UnitSelectScript.SelectedUnit.GetComponent<UnitDetails>();
            player = UnitSelectScript.SelectedUnit.GetComponent<Transform>();
            movementScript = UnitSelectScript.SelectedUnit.GetComponent<FPSMovement>();
        }

        float dist = Vector3.Distance(mouseLeader.position, player.position);
        float minDist = UnitDetails.range;

        if (dist > minDist)
        {
            mouseScript.enabled = false;
            Debug.Log("out of range");
        }
        else if (dist < minDist)
        {
            mouseScript.enabled = true;
            Debug.Log("in range");
        }
    }
}
