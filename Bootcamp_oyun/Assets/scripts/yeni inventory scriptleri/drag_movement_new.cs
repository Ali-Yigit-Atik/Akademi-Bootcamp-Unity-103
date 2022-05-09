using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_movement_new : MonoBehaviour
{
    private inventory_new inventory_;
    public GameObject target;
    private bool moving;
    public bool finish;

    private GameObject inventory__;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
    public static Vector3 mousePos_local;

    public static bool mouseUp = false;
    public static bool mouseDown = false;

    private bool isOnMouseEnter = false;

    public static bool place_correct=false;

    public static int slot_index__;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();


        //inventory__ = GameObject.FindGameObjectWithTag("inventory");
    }

    private void Update()
    {

        if (Right_Move1.isRightMove == true )
        {
            this.gameObject.transform.localPosition= new Vector3(this.gameObject.transform.localPosition.x + Right_Move1.rigthMovement, this.gameObject.transform.localPosition.y);
            resetPosition = this.transform.localPosition;
        }
        else if (left_move.isLeftMove == true)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + left_move.leftMovement, this.gameObject.transform.localPosition.y);
            resetPosition = this.transform.localPosition;
        }

        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
                mousePos_local = this.gameObject.transform.localPosition;
            }
        }

        mouseUp_And_down();
    }

    private void OnMouseDown()
    {
        mouseUp = false;
        mouseDown = true;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos;
        //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        //    startPosX = mousePos.x - this.transform.localPosition.x;
        //    startPosY = mousePos.y - this.transform.localPosition.y;
        //
        //    moving = true;
        //}
    }

    private void OnMouseUp()
    {

        mouseUp = true;
        mouseDown = false;

        // moving = false;
        //
        // if( Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) <= 0.5f && 
        //     Mathf.Abs(this.transform.localPosition.y - target.transform.localPosition.y) <=  0.5f)
        // {
        //     this.transform.position = target.transform.localPosition;
        //     finish = true;
        // }
        //
        // else
        // {
        //     this.transform.position = resetPosition;
        // }
    }


    private void OnMouseEnter()
    {
        isOnMouseEnter = true;
    }

    private void OnMouseExit()
    {
        isOnMouseEnter = false;
    }
    void mouseUp_And_down()
    {

        this.gameObject.GetComponent<pickup_new>().enabled = false;

        if (isOnMouseEnter == true && mouseDown == true && mouseUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.localScale = new Vector3((float)pickup_new.object_dimension.x, (float)pickup_new.object_dimension.y, pickup_new.object_dimension.z);
                
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                moving = true;
            }
        }

        if (mouseUp == true && mouseDown == false)
        {
            moving = false;

            if (Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) <= 0.5f &&
                Mathf.Abs(this.transform.localPosition.y - target.transform.localPosition.y) <= 0.5f)
            {

                
                this.transform.position = target.transform.localPosition;
                

                //Destroy(pickup_new.EmptyObj.transform.parent.GetChild(0));
                //inventory_.isFull[slot_index__] = false; 

                //Debug.Log("inventory: "+inventory_.isFull[slot_index__]);

                //inventory_empty();

                place_correct = true;
                //transform.parent = null;

                finish = true;
            }

            else
            {
                this.transform.position = resetPosition;
                transform.localScale = new Vector3((float) pickup_new.object_dimension.x / 2f, (float) pickup_new.object_dimension.y / 2f, pickup_new.object_dimension.z);

                //if(place_correct ==false) inventory_.isFull[slot_index__] = true;
                
                place_correct = false;

                finish = false;
            }
        }
    }

    void inventory_empty()
    {
       //for (int i = 0; i < inventory_.slots.Length; i++)
       //{
       //    if (inventory_.isFull[i] == true &&  (pickup_new.slot_Index==i))
       //    {
       //
       //        inventory_.isFull[i] = false;               
       //
       //
       //           
       //        break;
       //    }
       //}


        if(finish ==true)
        {
            inventory_.isFull[slot_index__] = false;
        }
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
       slot_index__=other.GetComponent<slot_number>().Slot_Number_;
   }

   
}
