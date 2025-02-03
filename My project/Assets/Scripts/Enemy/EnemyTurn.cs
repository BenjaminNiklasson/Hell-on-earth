using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    GameObject player;
    bool facingRight = true;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x && facingRight == true)
        {
            transform.localScale += new Vector3 (-1,0,0)
            facingRight = false;
        }
        else if (player.transform.position.x > transform.position.x && facingRight == false)
        {
            transform.Rotate(new Vector3 (0, 180, 0));
            facingRight = true;
        }
    }
}
