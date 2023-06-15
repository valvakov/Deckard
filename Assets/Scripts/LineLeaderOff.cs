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

    public int CurrentStat;

    public UnitSelect UnitSelectScript;

    void Start()
    {

    }
    void Update()
    {
        player = UnitSelectScript.SelectedUnit.GetComponent<Transform>();
        movementScript = UnitSelectScript.SelectedUnit.GetComponent<FPSMovement>();

        float dist = Vector3.Distance(mouseLeader.position, player.position);
        float minDist = movementScript.mv;

        if(dist > minDist)
        {
            movementScript.enabled = false;
            mouseScript.enabled = false;
            Debug.Log("out of range");
        }
        else if(dist < minDist)
        {
            movementScript.enabled = true;
            mouseScript.enabled = true;
            Debug.Log("in range");
        }
    }
}
