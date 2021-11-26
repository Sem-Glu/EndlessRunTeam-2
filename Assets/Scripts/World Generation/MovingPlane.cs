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
    private Vector3 planeUnmovement;
    [SerializeField]
    private float sssspeeed;
  
    void Start()
    {
        planeBody = GetComponent<Rigidbody>();
        planeTransform = GetComponent<Transform>();

        //zet direction naar voor
       planeMovement = new Vector3(1, 0, 0);
       planeUnmovement = new Vector3(0, 0, 0);
       sssspeeed = sssspeeed + 15;
    }
    private void FixedUpdate()
    {
        //set velocity to direction times speed
        if (GenerationScript.Instance.gameStart == true)
        {
            planeBody.velocity = planeMovement * sssspeeed;
            //planeBody.transform.position = planeMovement * sssspeeed * Time.fixedDeltaTime;
        }
        else
        {
            planeBody.velocity = planeUnmovement;
        }
        
    }
}
