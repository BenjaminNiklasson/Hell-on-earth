using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailerTurning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float scaleChange = -1;
    [SerializeField] float scaleY;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<RailerMovement>().isShooting == false)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3 (-scaleChange,scaleY,1);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3 (scaleChange, scaleY, 1);
            }
        }
    }
}
