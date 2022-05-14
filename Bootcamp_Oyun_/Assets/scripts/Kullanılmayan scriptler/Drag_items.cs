using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_items : MonoBehaviour
{
    //public GameObject gameobject_;
    public GameObject gameobject_target;

    Vector2 gameobject_initialPosition;

    private bool mouse_enter = false;

    float distance_;

    Vector3 mouseWorldPosition;

    void Start()
    {
        gameobject_initialPosition = gameObject.transform.position;
    }

    private void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        if ( mouse_enter == true)
        {
            if (Input.GetMouseButton(0))
            {
                //drag_object();
                gameObject.transform.position = mouseWorldPosition;

                distance_ = Vector3.Distance(gameObject.transform.position, gameobject_target.transform.position);
                Debug.Log("mouse koordinatý: "+ mouseWorldPosition);
                Debug.Log("distance: " + distance_);

                //if (Input.GetMouseButtonDown(0))
                //{
                    //drop_object();
                    if (Input.GetMouseButton(0)==false && distance_ < 1f)
                    {
                        gameObject.transform.position = gameobject_target.transform.position;
                        Debug.Log("mesafe: " + gameobject_target.transform.position);
                    }
                    
                //}

            }
            else
            {
                gameObject.transform.position = gameobject_initialPosition;
            }

        }
    }

   // public void drag_object()
   // {
   //     gameObject.transform.position = Input.mousePosition;
   //
   // }

    //public void drop_object()
    //{
    //    float distance_ = Vector3.Distance(gameObject.transform.position, gameobject_target.transform.position);
    //
    //    
    //    if (distance_ < 0.5f)
    //    {
    //        gameObject.transform.position = gameobject_target.transform.position;
    //        Debug.Log("mesafe: "+gameobject_target.transform.position);
    //    }
    //    else
    //    {
    //        gameObject.transform.position = gameobject_initialPosition;
    //    }
    //}
    //

    private void OnMouseEnter()
    {
        mouse_enter = true;
    }

    private void OnMouseExit()
    {
        mouse_enter = false;
    }

    
}
