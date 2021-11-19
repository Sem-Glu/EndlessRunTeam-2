using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private PlayerMovement m_playerMovement;

    private void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hostile"))
        {
            m_playerMovement.Restart();
        }
    }
}
