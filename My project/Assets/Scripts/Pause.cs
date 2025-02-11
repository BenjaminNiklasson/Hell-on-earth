using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    bool paused = false;
    void OnPause()
    {
        if (paused == false)
        {
            Debug.Log("THE WORLD!!!");
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Debug.Log("LET THERE BE LIGHT!!!");
            Time.timeScale = 1;
            paused = false;
        }
        
    }
}
