using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public KeyCode m_forward;
    public KeyCode m_back;
    public KeyCode m_left;
    public KeyCode m_right;
    public float m_runSpeed = 1.5f;
    public KeyCode m_sprint;

    public UnityEngine.CharacterController m_charControler;
    public float m_movementSpeed = 12f;

    public float m_gravity = -9.81f;
    private Vector3 m_velocity;
    private float m_finalSpeed = 0;

    void Awake()
    {
        m_finalSpeed = m_movementSpeed;
    }

    void Update()
    {
        MoveInputCheck();
    }

    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = Vector3.zero;

        if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right))
        {
            move = transform.right * x + transform.forward * z;        
        }

        MovePlayer(move); 
    }

    void MovePlayer(Vector3 move)
    {
        m_charControler.Move(move * m_finalSpeed * Time.deltaTime); 

        m_velocity.y += m_gravity * Time.deltaTime; 
        m_charControler.Move(m_velocity * Time.deltaTime); 
    }
}

