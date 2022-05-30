using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hider_objects : MonoBehaviour
{
    public float x = 0;
    public float y = 0;


    private bool onenter = false;
    public GameObject saklanan_nesne;

    private bool isFirstTimeTouched=true;

    private void Awake()
    {
        //saklanan_nesne =GameObject.GetComponent<Collider2D>();
        //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = false;
        saklanan_nesne.gameObject.SetActive(false);
    }

    private void Update()
    {
     if(onenter ==true && isFirstTimeTouched == true && Input.GetMouseButtonDown(0))
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + x, this.gameObject.transform.position.y + y, this.gameObject.transform.position.z);

            //saklanan_nesne.gameObject.GetComponent<Collider2D>().enabled = true;
            saklanan_nesne.gameObject.SetActive(true);

            isFirstTimeTouched = false;

            this.gameObject.GetComponent<mouse_effect>().enabled = false;
            this.gameObject.tag = "Untagged";

            if (this.gameObject.transform.childCount == 1)   // Game objenin içindeki ipucu iþaretlerini silme
            {
                
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
               
            }
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
