using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddToArray : MonoBehaviour
{
    public SwitchCamera SwitchCamera;

    void Start()
    {
        SwitchCamera.Player1.Add(gameObject);
        SwitchCamera.Player2.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
