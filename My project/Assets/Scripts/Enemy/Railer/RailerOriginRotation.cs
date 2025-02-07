using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RailerOriginRotation : MonoBehaviour
{
    GameObject player;
    RailerMovement rm;
    public bool stopRotating = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rm = transform.parent.parent.GetComponent<RailerMovement>();
    }
    void Update()
    {
        if (rm.isShooting == false && stopRotating == false)
        {
            if (player.transform.position.x < transform.parent.parent.transform.position.x)
            {
                transform.Rotate(180, 0, 0);
            }
            else if (player.transform.position.x > transform.parent.parent.transform.position.x)
            {
                transform.Rotate(180, 0, 0);
            }
        }
    }
}
