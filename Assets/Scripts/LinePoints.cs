using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    public Transform[] points;
    public MouseLine line;
    public Transform LineLeader;
    public UnitSelect UnitSelectScript;
    public SwitchCamera SwitchCamera;
    public GameObject SelectedCamera;

    private void Start()
    {
        line.SetUpLine(points);
    }

    public void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            points[0] = null;
        } 

        SelectedCamera = SwitchCamera.SelectedCamera;
        UnitSelectScript = SelectedCamera.GetComponent<UnitSelect>();

        points[0] = UnitSelectScript.SelectedUnit.GetComponent<Transform>();
        points[1] = LineLeader.transform;

    }
}