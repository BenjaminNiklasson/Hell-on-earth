using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMouthScript : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<AspidShooting>().isShooting == true)
        {
            ani.SetBool("isShooting", true);
        }
        else
        {
            ani.SetBool("isShooting", false);
        }
    }
}
