using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLeaderOff : MonoBehaviour
{
    public object mouseFollow;
    public Transform mouseLeader;
    public Transform player;
    public FPSMovement movementScript;
    public MouseFollow mouseScript;

    public GameObject SelectedCamera;

    public UnitDetails UnitDetails;

    public UnitSelect UnitSelectScript;

    public SwitchCamera SwitchCamera;

    void Start()
    {
        mouseScript.enabled = true;
    }
    void Update()
    {
        SelectedCamera = SwitchCamera.SelectedCamera;

        UnitSelectScript = SelectedCamera.GetComponent<UnitSelect>();

        if (UnitSelectScript.SelectedUnit == null)
        {
            mouseScript.enabled = true;
        }

        if (UnitSelectScript.SelectedUnit != null)
        {
            UnitDetails = UnitSelectScript.SelectedUnit.GetComponent<UnitDetails>();
            player = UnitSelectScript.SelectedUnit.GetComponent<Transform>();
            movementScript = UnitSelectScript.SelectedUnit.GetComponent<FPSMovement>();

            float dist = Vector3.Distance(mouseLeader.position, player.position);
            float minDist = UnitDetails.mv;

            if (dist > minDist)
            {
                movementScript.enabled = false;
                mouseScript.enabled = false;
                Debug.Log("out of range");
            }
            else if (dist < minDist)
            {
                movementScript.enabled = true;
                mouseScript.enabled = true;
                Debug.Log("in range");
            }
        }
    }
}
