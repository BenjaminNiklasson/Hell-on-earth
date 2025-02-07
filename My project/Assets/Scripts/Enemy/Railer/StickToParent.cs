using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToParent : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.transform.position;
        transform.rotation = transform.parent.transform.rotation;
    }
}
