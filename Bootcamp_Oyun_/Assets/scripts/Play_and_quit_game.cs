using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_and_quit_game : MonoBehaviour
{

    
    
    public void Start_game(string nextScene)
    {
        SceneManager.LoadScene(nextScene); // oyunu baþlatma
    }

    public void quit_game()
    {
        
        Application.Quit(); // oyundan çýkma
    }
}
