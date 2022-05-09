using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private inventory inventory_;
    public static int slot_index; // alýnan eþyalar yanlýþ slot'a gitmesin diye bu index sayýsýný game objennin inspector'ýnda gireceðiz
    Transform[] ts;

    private Vector3 mouseWorldPosition__; // 

    public static GameObject slot_object; //
    private Drag_movement drag_script; //
    private pickup pickup_script; //

    void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory>();
        ts = GetComponentsInChildren<Transform>();

        
    }

    
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory_.isFull[slot_index] = false; // Burayý inventory de bug olup boþ slot kalmasýzn diye yazdýk
        }
        mouseWorldPosition__ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition__.z = 0f;
    }

    public void DragItem()
    {


        foreach (Transform child in transform)
        {
            //GameObject.Destroy(child.gameObject);

            child.GetComponent<spawn>().item_spawn();
            //child.GetComponent<spawn>().itemSpawn.GetComponent<Drag_movement>().enabled = true;

            //child.GetComponent<spawn>().itemSpawn.GetComponent<pickup>().enabled = false;

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            slot_object = gameObject.transform.GetChild(0).gameObject;

            //if (Drag_movement.place_correct == true)
            //{
            //    GameObject.Destroy(child.gameObject);
            //}
            //else if(Drag_movement.place_correct==false && Drag_movement.mouseUp == true && Drag_movement.mouseDown == false)
            //{
            //    gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //}

            //spawn.item_spawn();
            //Drag_movement.mouseUp_And_down();
        }









        //foreach(Transform child in transform)
        //{
        //GameObject.Destroy(child.gameObject);
        //if (ts.Length != 0)
        //{
        //
        //    //gameObject.transform.GetChild(0).gameObject.GetComponent<spawn>().item_spawn();
        //    Instantiate(gameObject.transform.GetChild(0).gameObject.GetComponent<spawn>().itemSpawn, mouseWorldPosition__, Quaternion.identity); // item mouse pozisyonumuzun olduðu yerde baþlayacak
        //
        //    slot_object = gameObject.transform.GetChild(0).gameObject;
        //    Destroy(gameObject.transform.GetChild(0).gameObject);
        //    
        //
        //    drag_script = gameObject.transform.GetChild(0).gameObject.GetComponent<spawn>().itemSpawn.GetComponent<Drag_movement>();
        //
        //    pickup_script = gameObject.transform.GetChild(0).gameObject.GetComponent<spawn>().itemSpawn.GetComponent<pickup>();
        //
        //    drag_script.enabled = true;
        //
        //    pickup_script.enabled = false;
        //}
        //
        //if (Drag_movement.place_correct == false)
        //{
        //    Instantiate(slot.slot_object, inventory_.slots[slot.slot_index].transform.position, Quaternion.identity, inventory_.slots[slot.slot_index].transform);
        //}
        //

        //child.GetComponent<spawn>().itemSpawn.GetComponent<Drag_movement>().enabled = true;

        //child.GetComponent<spawn>().itemSpawn.GetComponent<pickup>().enabled = false;

        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //slot_object = gameObject.transform.GetChild(0).gameObject;

        //if (Drag_movement.place_correct == true)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}
        //else if(Drag_movement.place_correct==false && Drag_movement.mouseUp == true && Drag_movement.mouseDown == false)
        //{
        //    gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //}

        //spawn.item_spawn();
        //Drag_movement.mouseUp_And_down();
        //}
    }

    
}
