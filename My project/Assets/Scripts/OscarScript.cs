using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    VisualElement _root;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
    }
    private void Start()
    {
        UnsignedIntegerField playerHeartField = _root.Q<UnsignedIntegerField>("PlayerHeartField");
        VisualElement playerHeartContainer = _root.Q<VisualElement>("PlayerHeartContainer");
        playerHeartField.RegisterCallback<NavigationSubmitEvent>(evt => CreatePlayerHearts(playerHeartContainer, playerHeartField.value));
    }

    private void CreatePlayerHearts(VisualElement playerHeartContainer, uint playerHearts)
    {
        playerHeartContainer.Clear();
        for (int i = 0; i < playerHearts; i++)
        {
            VisualElement playerHeart = new VisualElement();
            playerHeart.AddToClassList("playerHeart");
            playerHeartContainer.Add(playerHeart);
        }
    }






}
