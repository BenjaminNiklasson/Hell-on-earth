using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailerLooking : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //bool stopMoving = RailerMovement.IsMoving();
        //if (stopMoving == false)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        //    transform.rotation = new Quaternion(rotation.x, rotation.y, 0,0);
        //}
        
    }
}
