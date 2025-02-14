using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

[System.Serializable]

public class ButtonEvent
{
    [SerializeField] string _buttonName = "";
    [SerializeField] UnityEvent _unityEvent;
    Button _button;
    



    public void Activate(UIDocument document)
    {
        if (_button == null)
        {
            _button = document.rootVisualElement.Q<Button>(_buttonName);
        }

        _button.clicked += _unityEvent.Invoke;
    }

    public void Inactivate(UIDocument document)
    {
        _button.clicked -= _unityEvent.Invoke;
    }
}

public class OscarScript : MonoBehaviour
{
    [SerializeField] UIDocument _document;
    [SerializeField] List<ButtonEvent> _buttonEvents;
    GameObject spawnSys;


    VisualElement _curMenu = null;
    Label waveLabel;

    VisualElement _root;
    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
    }

    public void Level2Unlock()
    {
        VisualElement lvl2Lock = _root.Q<VisualElement>("Lvl2Lock");
        Button playLvl2Button = _root.Q<Button>("PlayLvl2Button");
        lvl2Lock.style.display = DisplayStyle.None;
        playLvl2Button.style.display = DisplayStyle.Flex;
    }

    public void Level3Unlock()
    {
        VisualElement lvl3Lock = _root.Q<VisualElement>("Lvl3Lock");
        Button playLvl3Button = _root.Q<Button>("PlayLvl3Button");
        lvl3Lock.style.display = DisplayStyle.None;
        playLvl3Button.style.display = DisplayStyle.Flex;
    }

    public void Level4Unlock()
    {
        VisualElement lvl4Lock = _root.Q<VisualElement>("Lvl4Lock");
        Button playLvl4Button = _root.Q<Button>("PlayLvl4Button");
        lvl4Lock.style.display = DisplayStyle.None;
        playLvl4Button.style.display = DisplayStyle.Flex;
    }

    public void SwitchMenu(string menuName)
    {
        _curMenu.style.display = DisplayStyle.None;
        _curMenu = _document.rootVisualElement.Q<VisualElement>(menuName);
        _curMenu.style.display = DisplayStyle.Flex;
        Time.timeScale = 1;
    }

    void Start()
    {
        Time.timeScale = 1;
        // Level Name
        Label levelName = _root.Q<Label>("LevelName");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (currentSceneIndex)
        {
            case 2:
                levelName.text = "1 - Street";
                break;
            case 3:
                levelName.text = "2 - Office";
                break;
            case 4:
                levelName.text = "3 - Hell";
                break;
            case 5:
                levelName.text = "4 - Bossfight";
                break;
        }

        //Wave Name
        waveLabel = _root.Q<Label>("WaveName");
        spawnSys = GameObject.FindWithTag("EnemySpawnSystem");
    }
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }



    private void OnEnable()
    {
        _buttonEvents.ForEach(button => button.Activate(_document));
    }

    private void OnDisable()
    {
        _buttonEvents.ForEach(button => button.Inactivate(_document));
    }

    private void Update()
    {
        string waveString = $"Wave {spawnSys.GetComponent<EnemySpawn>().currentWave}/{spawnSys.GetComponent<EnemySpawn>().maxWaves}";
        waveLabel.text = waveString;
    }

    public void UnPause()
    {
        VisualElement pauseVisualTree = _root.Q<VisualElement>("PausedVisualTree");
        pauseVisualTree.style.display = DisplayStyle.None;
        _curMenu = _document.rootVisualElement.Q<VisualElement>("HUDVisualTree");
        _curMenu.style.display = DisplayStyle.Flex;
        Time.timeScale = 1;
    }
}
