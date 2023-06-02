using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private MouseLine line;

    private void Start()
    {
        line.SetUpLine(points);
    }
}
