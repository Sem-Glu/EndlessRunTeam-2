using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData Data;
    private Rigidbody m_rigidbody;
    private Transform m_transform;
    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();

        //zet direction naar voor
        Data.direction = new Vector3(1, 0, 0);
    }

    private void Update()
    {
        //if key leftarrow/rightarrow is pressed MoveLane
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane("left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane("right");
        }
    }

    private void FixedUpdate()
    {
        //set velocity to direction times speed
        m_rigidbody.velocity = Data.direction * Data.speed * Time.fixedDeltaTime;
    }

    private void MoveLane(string direction)
    {
        if (direction == "left")
        {
            if (m_transform.position.z != 6.5)
            {
            m_transform.position = m_transform.position + new Vector3(0, 0, 2);
            }
        }
        else if (direction == "right")
        {
            if (m_transform.position.z != 2.5)
            {
                m_transform.position = m_transform.position + new Vector3(0, 0, -2);
            }
        }
    }

    public void Restart()
    {
        m_transform.position = Data.spawnPoint;
    }
}
