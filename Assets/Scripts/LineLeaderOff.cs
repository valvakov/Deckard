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

    void Start()
    {
        player = movementScript.selected = true;
    }



    void Update()
    {
        float dist = Vector3.Distance(mouseLeader.position, player.position);
        float minDist = 10;

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
