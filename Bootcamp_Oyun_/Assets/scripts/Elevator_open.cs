using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_open : MonoBehaviour
{
    public static int totalButtonSolved; // toplanan asansör düðmesi

    // Tüm asansör düðmeleri toplandýðýnda asansörün collider'ý aktif olacak ve bu þekilde üzerine týklanabilcek 
    // üzerine týklandýðýnda baþka bir script sayesinde sonraki sahneye geçiþ yapýlacak
    

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
