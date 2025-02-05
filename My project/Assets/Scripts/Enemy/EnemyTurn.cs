using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    GameObject player;
    [SerializeField] int scaleChange = -1;
    [SerializeField] int scaleY;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
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
