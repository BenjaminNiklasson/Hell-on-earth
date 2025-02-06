using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyFall : MonoBehaviour
{
    int firstRotate;
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float switchSpeed = 2f;
    bool goingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        int firstRotate = Random.Range(0, 2);
        Invoke("SwitchRotation", switchSpeed/2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingRight == true)
        {
            transform.Rotate(0, 0, rotateSpeed, 0);
        }
        else
        {
            transform.Rotate(0, 0, -rotateSpeed, 0);
        }
    }

    void SwitchRotation()
    {
        goingRight = !goingRight;
        Invoke("SwitchRotation", switchSpeed);
    }
}
