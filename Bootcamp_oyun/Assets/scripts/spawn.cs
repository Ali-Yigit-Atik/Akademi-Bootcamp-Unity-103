using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject itemSpawn;
    //public static GameObject itemSpawn;
    private Vector3 mouseWorldPosition_;
    private Drag_movement drag_script;
    private pickup pickup_script;



    private void Start()
    {
       // drag_script = itemSpawn.GetComponent<Drag_movement>();
       //
       // pickup_script = itemSpawn.GetComponent<pickup>();
       //
       // drag_script.enabled = true;
       //
       // pickup_script.enabled = false;
    }

    private void Update()
    {
      mouseWorldPosition_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mouseWorldPosition_.z = 0f;
      
    }

    public void item_spawn()
    {
        
        Instantiate(itemSpawn, mouseWorldPosition_, Quaternion.identity); // item mouse pozisyonumuzun olduðu yerde baþlayacak
        

        
    }
   
}
