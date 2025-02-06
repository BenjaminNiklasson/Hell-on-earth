using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeMoney : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion = Instantiate(Explosion, transform.position, new Quaternion (0,0,0,0));
        Destroy(transform.parent);
        Destroy(gameObject);
    }
}
