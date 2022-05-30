using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obje_saklama : MonoBehaviour
{

    private bool onenter = false;
    private bool isFirstTimeTouched = true;

   

    // Update is called once per frame
    private void Update()
    {
       if (onenter == true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
       {
           
       
           
           isFirstTimeTouched = false;
       
           if (this.gameObject.transform.parent.childCount> 0)   
           {
               
               for (int i = 1; i < this.gameObject.transform.parent.childCount-1; i++)
               {
                   //Destroy(this.gameObject.transform.GetChild(0).gameObject);
                   this.gameObject.transform.parent.GetChild(i).gameObject.SetActive(true);
               }


       
           }
            Destroy(this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount-1).gameObject);
            this.gameObject.SetActive(false);
        }
    }


    private void OnMouseEnter()
    {

        onenter = true;
    }

    private void OnMouseExit()
    {

        onenter = false;
    }
}

