using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorScript : MonoBehaviour
{
    Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("GotEntered", true);
            Destroy(GameObject.FindWithTag("Player"));
            Invoke("SwitchScene", 3f);
        }
    }

    private void SwitchScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
