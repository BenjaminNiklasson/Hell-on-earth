using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TokenAttempt2 : MonoBehaviour
{

    VisualElement _root;
    UnsignedIntegerField playerHeartField;
    VisualElement playerHeartContainer;
    GameObject player;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHeartField = _root.Q<UnsignedIntegerField>("PlayerHeartField");
        playerHeartContainer = _root.Q<VisualElement>("PlayerHeartContainer");
    }

    private void CreatePlayerHearts(VisualElement playerHeartContainer)
    {
        Debug.Log("hearts!");
        playerHeartContainer.Clear();
        for (int i = 0; i < (player.GetComponent<PlayerHealth>().GetHealth()); i++)
        {
            VisualElement PlayerHeart = new VisualElement();
            PlayerHeart.AddToClassList("playerHeart");
            playerHeartContainer.Add(PlayerHeart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreatePlayerHearts(playerHeartContainer);
    }
}
