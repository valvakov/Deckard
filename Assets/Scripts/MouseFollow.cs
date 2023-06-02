using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 newPosition;
    public Transform target;

    void Start()
    {
        newPosition = transform.position;
    }


    void Update()
    {
        {
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    newPosition = hit.point;
                    transform.position = newPosition;
                }

            }
        }
    }
}