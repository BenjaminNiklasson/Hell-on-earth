using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    [SerializeField] float despawnTimer = 1f;
    void Start()
    {
        Invoke ("DespawnObject", despawnTimer);
    }

    void DespawnObject()
    {
        Destroy(gameObject);
    }
}
