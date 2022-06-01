using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hider_objects : MonoBehaviour
{
    public float x = 0; // nesnenin x ekseninde kayma miktarý
    public float y = 0;  // nesnenin y ekseninde kayma miktarý


    private bool onenter = false; // mouse nesnenin üzerinde mi
    public GameObject saklanan_nesne; // saklanacak olan nesne

    private bool isFirstTimeTouched=true; // bu nesneye ilk defa mý týklanacak 

    private void Awake()
    {
        //saklanan_nesne =GameObject.GetComponent<Collider2D>();
        //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = false;

        saklanan_nesne.gameObject.SetActive(false); // saklanan nesneyi pasif hale getirme buglardan kaçýnmak için
    }

    private void Update()
    {
     
        // Nesnenin üzerine týklandýðýnda nesne yana kaysýn ve etkileþimli nesne olmaktan çýksýn. Ayrýca saklanan nesne aktif hale gelsin kodlarý:
        if(onenter ==true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + x, this.gameObject.transform.position.y + y, this.gameObject.transform.position.z);

            //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = true;
            saklanan_nesne.gameObject.SetActive(true); //saklanan nesne aktif hale gelsin

            isFirstTimeTouched = false;

            this.gameObject.GetComponent<mouse_effect>().enabled = false; /// etkileþimli nesne olmaktan çýkarma
            this.gameObject.tag = "Untagged";

            if (this.gameObject.transform.childCount == 1)   // Game objenin içindeki ipucu iþaretlerini silme
            {
                
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
               
            }
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
