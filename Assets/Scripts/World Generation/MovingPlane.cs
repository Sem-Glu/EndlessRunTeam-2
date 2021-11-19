using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    private Rigidbody planeBody;
    private Transform planeTransform;
   
    [SerializeField]
    private Vector3 planeMovement;
    [SerializeField]
    private float sssspeeed;
  
    void Start()
    {
        planeBody = GetComponent<Rigidbody>();
        planeTransform = GetComponent<Transform>();

        //zet direction naar voor
       planeMovement = new Vector3(1, 0, 0);
       sssspeeed = sssspeeed + 300;
    }
    private void FixedUpdate()
    {
        //set velocity to direction times speed
        planeBody.velocity = planeMovement * sssspeeed * Time.fixedDeltaTime;
    }
}
