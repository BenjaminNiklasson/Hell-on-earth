using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElonBullet : MonoBehaviour
{
    [SerializeField] GameObject splashRight;
    [SerializeField] GameObject splashLeft;
    [SerializeField] float spawndistance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
            Instantiate(splashLeft, new Vector3 (transform.position.x - spawndistance, transform.position.y + 1, transform.position.z), transform.rotation);
            Instantiate(splashRight, new Vector3 (transform.position.x + spawndistance, transform.position.y + 1, transform.position.z), transform.rotation);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
