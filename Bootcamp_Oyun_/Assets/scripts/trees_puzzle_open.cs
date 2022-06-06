using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees_puzzle_open : MonoBehaviour
{


    // Kahve puzzle'ý çözüldüðünde aðaç puzzleýnýn yapýlabilmesi için aðaçlarýn collider'larýný açma

    public Collider2D[] trees; 
    

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            for(int i=0; i<=trees.Length-1; i++)
            {
                trees[i].enabled = true;
            }
        }
    }
}
