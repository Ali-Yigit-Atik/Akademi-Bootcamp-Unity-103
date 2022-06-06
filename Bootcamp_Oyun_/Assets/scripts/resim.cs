using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resim : MonoBehaviour
{
    private bool isFirstTime = true; // ilk defa mý bu nesneye týklanacak
    public static bool pictureOpened = false;  // baþka bir scriptte resimin açýldýðýný haber almak için static bool oluþturldu

    private void Start()
    {
        pictureOpened = false;
    }
    private void Update()
    {
        // nesnenin üzerine týklandýðýnda bu nesne pasif hale gelsin ama kardeþ objeleri aktif olsun kodlarý:
        if (isFirstTime == true && pictureOpened == true)
        {

            isFirstTime = false;

            if (this.gameObject.transform.parent.childCount > 0)   // bu nesnenin ebeveyn objesinin içerisinde objeler varsa çalýþsýn komutu
            {

                for (int i = 1; i < this.gameObject.transform.parent.childCount - 1; i++)
                {
                    
                    this.gameObject.transform.parent.GetChild(i).gameObject.SetActive(true); // objeleri aktif hale getir
                }



            }
            Destroy(this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount - 1).gameObject); // ipucu iþaretini sil
                                                                                                                            // Not: ipucu iþareti ebeveny objesinin son çocuðu
            this.gameObject.SetActive(false); // bu objeyi pasif hale getir
        }
    }
}
