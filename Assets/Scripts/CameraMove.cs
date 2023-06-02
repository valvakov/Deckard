using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private bool dragActive;
    private Vector2 lastMousePos;
    

    void Start()
    {

    }

    void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);
        Vector3 moveDir = transform.forward * inputDir.z + transform.right;
        float moveSpeed = 50f;
        transform.position += inputDir * moveSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            dragActive=true;
            lastMousePos = Input.mouseScrollDelta;
        }
        if (Input.GetMouseButtonUp(1))
        {
            dragActive=false;
        }
        if (dragActive)
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePos;

            float dragPanSpeed = 2f;
            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;
        }
    }
}
