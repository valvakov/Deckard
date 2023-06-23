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

    public Ray g_ray = new Ray();
    public LayerMask obstacleLayer;
    public LayerMask playAreaLayer;

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

            g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(g_ray, Mathf.Infinity, obstacleLayer))
            {
                movementScript.enabled = false;
                mouseScript.enabled = false;
            }
            if (Physics.Raycast(g_ray, Mathf.Infinity, playAreaLayer))
            {
                movementScript.enabled = true;
                mouseScript.enabled = true;
            }
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
