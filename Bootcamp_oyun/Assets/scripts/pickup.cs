using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    private inventory inventory_;
    public GameObject itemButton;
    
    private bool mouse_enter=false;

    private bool firstTimeInIventory = true; //
    //public Texture2D selftexture;

    private pickup pickUp; //
    

    private void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory>();
        pickUp = GetComponent<pickup>(); //
    }

    private void Update()
    {
        if (mouse_enter == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < inventory_.slots.Length; i++)
                {
                    if (inventory_.isFull[i] == false)
                    {
                        
                        inventory_.isFull[i] = true;                        
                        Instantiate(itemButton, inventory_.slots[i].transform.position, Quaternion.identity, inventory_.slots[i].transform);


                        //this.gameObject.GetComponent<Drag_movement>().enabled = true;
                        Destroy(gameObject);
                        //gameObject.SetActive(false);
                        //pickUp.enabled = false;
                        
                        break;
                    }
                }
            }
            
        }
    }

   // private void OnMouseEnter()
   // {
   //     if (mouse_downed ==true)
   //     {
   //         for(int i=0; i<=inventory_.slots.Length; i++)
   //         {
   //             if(inventory_.isFull[i]== false)
   //             {
   //                 inventory_.isFull[i] = true;
   //                 Instantiate(itemButton, inventory_.slots[i].transform, false); // False buraya world koordinat olmasýn diye yazdým
   //                 Destroy(gameObject);
   //                 mouse_downed = false;
   //                 break;
   //             }
   //         }
   //     }
   // }

    private void OnMouseEnter()
    {
        mouse_enter = true;
    }

    private void OnMouseExit()
    {
        mouse_enter = false;
    }
}
