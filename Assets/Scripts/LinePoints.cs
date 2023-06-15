using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    public Transform[] points;
    public MouseLine line;
    public Transform LineLeader;
    public UnitSelect UnitSelectScript;

    private void Start()
    {
        line.SetUpLine(points);
    }

    public void Update ()
    {
        points[0] = UnitSelectScript.SelectedUnit.GetComponent<Transform>();
        points[1] = LineLeader.transform;

    }
}