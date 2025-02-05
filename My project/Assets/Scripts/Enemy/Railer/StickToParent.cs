using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToParent : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindWithTag("LaserOrigin");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.transform.position;
        transform.rotation = parent.transform.rotation;
    }
}
