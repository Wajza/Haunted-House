using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator m_Animator;
    public InputAction MoveAction;
    AudioSource m_AudioSource;

    public float walkSpeed = 5.0f;
    public float turnSpeed = 20f;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Vector2 m_InputVector; // Added to store input safely
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody> ();
        MoveAction.Enable();
        m_Animator = GetComponent<Animator> ();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Continuously catches every hardware input frame cleanly
        m_InputVector = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate ()
    {
        // Uses the cached vector for physics calculations
        float horizontal = m_InputVector.x;
        float vertical = m_InputVector.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        m_Animator.SetBool ("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        if (isWalking)
        {
            Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.fixedDeltaTime, 0f);
            m_Rotation = Quaternion.LookRotation (desiredForward);
            m_Rigidbody.MoveRotation (m_Rotation);
        }
        
        Vector3 targetVelocity = m_Movement * walkSpeed;
        targetVelocity.y = m_Rigidbody.linearVelocity.y; 
        m_Rigidbody.linearVelocity = targetVelocity;
    }

    private void OnDestroy()
    {
        // Prevents internal memory leaks from active inputs
        MoveAction.Disable();
    }
}
