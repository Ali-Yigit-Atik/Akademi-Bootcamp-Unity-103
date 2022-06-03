using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class papirus_puzzle_open : MonoBehaviour
{
    public static int totalCoffeePuzzleSolved;

    public GameObject papirus;

    private void Start()
    {
        papirus.SetActive(false);
        totalCoffeePuzzleSolved = 0;
    }

    private void Update()
    {
        if(totalCoffeePuzzleSolved == 3)
        {
            papirus.SetActive(true);
        }

        //if(SceneManager.GetActiveScene().name != "AVMScene")
        //{
        //    papirus.SetActive(false);
        //}
    }
}
