using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData Data;
    private Rigidbody m_rigidbody;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        Data.direction = new Vector3(1, 0, 0);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = Data.direction * Data.speed * Time.fixedDeltaTime;
    }
}
