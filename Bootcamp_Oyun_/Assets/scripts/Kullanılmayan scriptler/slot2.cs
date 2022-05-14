using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot2 : MonoBehaviour
{
    private inventory inventory_;
    public int slot_index; // alýnan eþyalar yanlýþ slot'a gitmesin diye bu index sayýsýný game objennin inspector'ýnda gireceðiz

    public static GameObject slot_object;

    void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory>();

    }


    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory_.isFull[slot_index] = false; // Burayý inventory de bug olup boþ slot kalmasýzn diye yazdýk
        }

        
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
    }

}
