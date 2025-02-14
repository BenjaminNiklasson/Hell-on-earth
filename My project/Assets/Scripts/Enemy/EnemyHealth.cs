using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] bool enemyIsAAspid;
    [SerializeField] bool enemyIsATank;
    [SerializeField] bool enemyIsARailgunner;
    [SerializeField] bool enemyIsAElonBezos;
    [SerializeField] int AspidHealth = 3;
    [SerializeField] int TankHealth = 30;
    [SerializeField] int RailgunnerHealth = 6;
    [SerializeField] int ElonBezosHealth = 666;
    int _enemyHealth;

    private void Start()
    {
        if (enemyIsAAspid)
        {
            _enemyHealth = AspidHealth * 2;
        }
        else if (enemyIsARailgunner)
        {
            _enemyHealth = RailgunnerHealth * 2;
        }
        else if (enemyIsATank)
        {
            _enemyHealth = TankHealth * 2;
        }
        else if (enemyIsAElonBezos)
        {
            _enemyHealth = ElonBezosHealth * 2;
        }
        
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemyHealth -= 2;
            if (_enemyHealth < 1)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("MinigunBullet"))
        {
            _enemyHealth--;
            if (_enemyHealth < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
