using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_and_quit_game : MonoBehaviour
{
    public void Start_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // oyunu ba�latma
    }

    public void quit_game()
    {
        Debug.Log("quit xxxx");
        Application.Quit(); // oyundan ��kma
    }
}
