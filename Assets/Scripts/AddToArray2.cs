using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToArray2 : MonoBehaviour
{
    public SwitchCamera SwitchCamera;

    void Start()
    {
        SwitchCamera.Player2.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

