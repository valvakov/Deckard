using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public MouseLine line;
    public Transform LineLeader;
    public UnitSelect UnitSelectScript;

    private void Start()
    {
        line.SetUpLine(points);
        UpdatedSelectedUnit();
    }

    public void UpdatedSelectedUnit ()
    {
        points[0] = UnitSelectScript.SelectedUnit.transform;
        points[1] = LineLeader.transform;

    }
}


/*
public LinePoints lP;
lP = FindObjectOfType<LinePonts>();

lP.UpdatedSelectedUnit(thingIClicked);

*/