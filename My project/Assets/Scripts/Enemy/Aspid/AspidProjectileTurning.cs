using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AspidProjectileTurning : MonoBehaviour
{
    GameObject player;
    [SerializeField] float xScale = 1;
    [SerializeField] float yScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(rotation.x, rotation.y, 0, 0);
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(xScale, yScale, 1);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-xScale, yScale, 1);
        }
    }
}
