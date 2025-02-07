using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    GameObject player;
    bool facingRight = true;
    [SerializeField] int scaleChange = -1;
    [SerializeField] int scaleY;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x && facingRight == true)
        {
            transform.localScale = new Vector3 (scaleChange,scaleY,1);
            facingRight = false;
        }
        else if (player.transform.position.x > transform.position.x && facingRight == false)
        {
            transform.localScale = new Vector3 (scaleChange, scaleY, 0);
            facingRight = true;
        }
    }
}
