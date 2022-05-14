using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_number : MonoBehaviour
{
    public int Slot_Number_;
    private inventory_new inventory_;

    //public Collider2D objectCollider ;
    //public Collider2D anotherCollider;

    public float maxDistance = 0.7f;


    private void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();
        
   
    }
    void Update()
    {


        //if (drag_movement_new.place_correct == true && this.gameObject.transform.childCount > 0)
        //{
        //    inventory_.isFull[Slot_Number_] = false; // Burayý inventory de bug olup boþ slot kalmasýzn diye yazdýk
        //
        //    Destroy(gameObject.transform.GetChild(0).gameObject);
        //}

        //SomeMethod();
       //
       //if (drag_movement_new.place_correct == true && pickup_new.slot_Index==Slot_Number_)
       //{
       //    inventory_.isFull[Slot_Number_] = false;
       //}
       // else if(drag_movement_new.finish==false)
       // {
       //     inventory_.isFull[Slot_Number_] = true;
       // }
    }

  public void OnTriggerEnter2D(Collider2D collision)
  {
  //
  //     anotherCollider=collision.gameObject.GetComponent<Collider2D>();
       Debug.Log("nesneler deðiyor");
  //
  //     if (collision.gameObject.CompareTag("touchable"))
  //     {
  //         Debug.Log("nesneler deðiyor");
  //     }
  //    
  }

    


  
}
