using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyFall : MonoBehaviour
{
    int firstRotate;
    [SerializeField] float rotateSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        int firstRotate = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        switch (firstRotate)
        {
            case 1:
                while (transform.rotation.z < 45)
                {
                    transform.Rotate(0, 0, rotateSpeed);
                }
                break;
            case 2:
                while (transform.rotation.z > 45)
                {
                    transform.Rotate(0, 0, -rotateSpeed);
                }
                break;

        }
    }
}
