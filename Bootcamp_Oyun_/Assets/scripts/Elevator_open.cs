using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_open : MonoBehaviour
{
    public static int totalButtonSolved;

    

    private void Start()
    {
        this.gameObject.GetComponent<Collider2D>().enabled=false;
        totalButtonSolved = 0;
    }

    private void Update()
    {
        if (totalButtonSolved == 2)
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
