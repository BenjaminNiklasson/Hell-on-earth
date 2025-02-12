using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TokenAttempt2 : MonoBehaviour
{

    VisualElement _root;
    UnsignedIntegerField playerHeartField;
    VisualElement playerHeartContainer;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
    }

    // Start is called before the first frame update
    void Start()
    {
        UnsignedIntegerField playerHeartField = _root.Q<UnsignedIntegerField>("PlayerHeartField");
        VisualElement playerHeartContainer = _root.Q<VisualElement>("PlayerHeartContainer");
        playerHeartField.RegisterCallback<NavigationSubmitEvent>(evt => CreatePlayerHearts(playerHeartContainer, playerHeartField.value));
    }

    private void CreatePlayerHearts(VisualElement playerHeartContainer, uint PlayerHearts)
    {
        playerHeartContainer.Clear();
        for (int i = 0; i < PlayerHearts; i++)
        {
            VisualElement PlayerHeart = new VisualElement();
            PlayerHeart.AddToClassList("playerHeart");
            playerHeartContainer.Add(PlayerHeart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerHeartField.RegisterCallback<NavigationSubmitEvent>(evt => CreatePlayerHearts(playerHeartContainer, playerHeartField.value));
    }
}
