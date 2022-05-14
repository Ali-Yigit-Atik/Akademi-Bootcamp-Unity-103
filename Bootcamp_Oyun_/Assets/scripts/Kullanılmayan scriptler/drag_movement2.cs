using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_movement2 : MonoBehaviour
{
    public GameObject target;
    private bool moving;
    private bool finish;


    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
    public static Vector3 mousePos_local;

    public static bool mouseUp = false;
    public static bool mouseDown = false;

    private bool isOnMouseEnter = false;

    public static bool place_correct;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    private void Update()
    {
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
        if (isOnMouseEnter==true && mouseDown == true && mouseUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
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
                finish = true;

                place_correct = true;
            }

            else
            {
                this.transform.position = resetPosition;
                //slot.slot_object.SetActive(true);
                //place_correct = false;
            }
        }
    }
}
