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

    }

    public void Level3Unlock()
    {

    }

    public void Level4Unlock()
    {

    }

    public void SwitchMenu(string menuName)
    {
        if (_curMenu != null)
        {
            _curMenu.style.display = DisplayStyle.None;
        }
        _curMenu = _document.rootVisualElement.Q<VisualElement>(menuName);
        _curMenu.style.display = DisplayStyle.Flex;
    }

    void Start()
    {
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


}
