using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obje_saklama : MonoBehaviour
{

    private bool onenter = false; //mouse nesnenin üzerinde mi
    private bool isFirstTimeTouched = true; // ilk defa mý bu nesneye týklanacak

   
        
    private void Update()
    {
        // nesnenin üzerine týklandýðýnda bu nesne pasif hale gelsin ama kardeþ objeleri aktif olsun kodlarý:
       if (onenter == true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
       {
            
           isFirstTimeTouched = false;
       
           if (this.gameObject.transform.parent.childCount> 0)   // bu nesnenin ebeveyn objesinin içerisinde objeler varsa çalýþsýn komutu
            {
               
               for (int i = 1; i < this.gameObject.transform.parent.childCount-1; i++)
               {
                   //Destroy(this.gameObject.transform.GetChild(0).gameObject);
                   this.gameObject.transform.parent.GetChild(i).gameObject.SetActive(true); // objeleri aktif hale getir
               }


       
           }
            Destroy(this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount-1).gameObject); // ipucu iþaretini sil
                                                                                                  // Not: ipucu iþareti ebeveny objesinin son çocuðu
            this.gameObject.SetActive(false); // bu objeyi pasif hale getir
        }
    }


    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin üzerinde
    }

    private void OnMouseExit()
    {

        onenter = false; // mouse nesnenin üzerinde deðil
    }
}

