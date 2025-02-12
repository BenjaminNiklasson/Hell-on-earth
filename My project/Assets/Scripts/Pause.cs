using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    UIDocument _document;
    bool paused = false;
    string pauseMenu = "PausedVisualTree";
    string HUD = "HUDVisualTree";
    private void Start()
    {
        _document = transform.GetChild(0).GetComponent<UIDocument>();
    }
    void OnPause()
    {
        Debug.Log("yibeee");
        if (paused == false)
        {
            Debug.Log("THE WORLD!!!");
            paused = true;
            Time.timeScale = 0;
            SwitchMenu(pauseMenu);
        }
        else
        {
            Debug.Log("LET THERE BE LIGHT!!!");
            Time.timeScale = 1;
            paused = false;
            SwitchMenu(HUD);
        }
        
    }
    VisualElement _curMenu = null;

    public void SwitchMenu(string menuName)
    {
        if (_curMenu != null)
        {
            _curMenu.style.display = DisplayStyle.None;
        }
        _curMenu = _document.rootVisualElement.Q<VisualElement>(menuName);
        _curMenu.style.display = DisplayStyle.Flex;
    }
}
