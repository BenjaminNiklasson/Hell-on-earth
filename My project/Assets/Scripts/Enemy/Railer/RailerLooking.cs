using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class RailerLooking : MonoBehaviour
{
    GameObject player;
    RailerMovement rm;
    public bool stopAim = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rm = transform.parent.GetComponent<RailerMovement>();
    }
    void Update()
    {
        if (rm.isShooting == false && stopAim == false)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(rotation.x, rotation.y, 0,0);
        }
    }
}
