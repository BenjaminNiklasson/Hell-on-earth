using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailerShooting : MonoBehaviour
{
    [SerializeField] GameObject shootLaser;
    [SerializeField] GameObject railGun;
    // Start is called before the first frame update
    void Start()
    {
        GameObject laser = Instantiate(shootLaser, railGun.transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
