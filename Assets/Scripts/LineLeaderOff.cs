using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLeaderOff : MonoBehaviour
{
    public MouseFollow LineScript;
    public GameObject rangeBox;
    private Ray g_ray = new Ray();
    private RaycastHit g_hitObject;
    private RaycastHit g_hitRangeBox;
    public LayerMask g_layerToHit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        g_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(g_ray, out g_hitObject))
        {
            LineScript.enabled = false;
        }
        else
        {
            LineScript.enabled = true;
        }
    }
}
