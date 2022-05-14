using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_and_drag : MonoBehaviour
{
   //  private inventory_new inventory_;
   //  public GameObject itemButton;
   //  
   //  public static GameObject EmptyObj;
   //  
   //  private bool mouse_enter = false;
   //  
   //  private bool firstTimeInIventory = true; //
   //  //public Texture2D selftexture;
   //  
   //  public static Vector3 object_dimension;
   //  
   //  private int slot_Index;
   //  
   //  private pickup_new pickUp; //
   //  
   //  
   //  ///////////
   //  
   //  / private inventory_new inventory_;
   //  public GameObject target;
   //  private bool moving;
   //  private bool finish;
   //  
   //  private GameObject inventory__;
   //  
   //  private float startPosX;
   //  private float startPosY;
   //  
   //  private Vector3 resetPosition;
   //  public static Vector3 mousePos_local;
   //  
   //  public static bool mouseUp = false;
   //  public static bool mouseDown = false;
   //  
   //  private bool isOnMouseEnter = false;
   //  
   //  public static bool place_correct = false;
   //  
   //  public static int slot_index__;
   //  
   //  private void Awake()
   //  {
   //      //this.gameObject.GetComponent<drag_movement_new>().enabled = false;
   //  
   //  }
   //  
   //  private void Start()
   //  {
   //      inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();
   //      pickUp = GetComponent<pickup_new>(); //
   //  
   //      object_dimension = new Vector3((float)transform.localScale.x, (float)transform.localScale.y, transform.localScale.z);
   //  
   //      Debug.Log("nesne boyutu " + object_dimension);
   //  
   //      //EmptyObj = new GameObject("name");
   //  
   //      /////////
   //  
   //      //resetPosition = this.transform.localPosition;
   //  
   //  }
   //  
   //  private void Update()
   //  {
   //  
   //      if (finish == false)
   //      {
   //          if (moving)
   //          {
   //              Vector3 mousePos;
   //              mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   //  
   //              this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
   //              mousePos_local = this.gameObject.transform.localPosition;
   //          }
   //      }
   //  
   //  
   //  
   //      if (firstTimeInIventory == true)
   //      {
   //          pick_up();
   //      }
   //  
   //      if (isOnMouseEnter == true) { mouseUp_And_down(); }
   //  }
   //  
   //  private void pick_up()
   //  {
   //      if (mouse_enter == true)
   //      {
   //          if (Input.GetMouseButtonDown(0))
   //          {
   //  
   //  
   //              for (int i = 0; i < inventory_.slots.Length; i++)
   //              {
   //                  if (inventory_.isFull[i] == false)
   //                  {
   //  
   //                      inventory_.isFull[i] = true;
   //  
   //                      slot_Index = i;
   //  
   //  
   //  
   //                      
   //  
   //                      transform.localScale = new Vector3((float)object_dimension.x / 2f, (float)object_dimension.y / 2f, object_dimension.z);
   //  
   //                      
   //                      this.gameObject.transform.position = inventory_.slots[i].transform.position;
   //  
   //                      resetPosition = this.gameObject.transform.position;
   //  
   //                      Debug.Log("yeni nesne boyutu " + transform.localScale);
   //                      firstTimeInIventory = false;
   //  
   //  
   //                      
   //                      break;
   //                  }
   //              }
   //          }
   //  
   //      }
   //  }
   //  
   //  private void OnMouseDown()
   //  {
   //      mouseUp = false;
   //      mouseDown = true;
   //      
   //  }
   //  
   //  private void OnMouseUp()
   //  {
   //  
   //      mouseUp = true;
   //      mouseDown = false;
   //  
   //      
   //  }
   //  
   //  private void OnMouseEnter()
   //  {
   //      mouse_enter = true;
   //      isOnMouseEnter = true;
   //  }
   //  
   //  private void OnMouseExit()
   //  {
   //      mouse_enter = false;
   //      isOnMouseEnter = false;
   //  }
   //  
   //  void mouseUp_And_down()
   //  {
   //  
   //      
   //  
   //      if (isOnMouseEnter == true && mouseDown == true && mouseUp == false)
   //      {
   //          if (Input.GetMouseButtonDown(0))
   //          {
   //              transform.localScale = new Vector3((float)pickup_new.object_dimension.x, (float)pickup_new.object_dimension.y, pickup_new.object_dimension.z);
   //  
   //              Vector3 mousePos;
   //              mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   //  
   //              startPosX = mousePos.x - this.transform.localPosition.x;
   //              startPosY = mousePos.y - this.transform.localPosition.y;
   //  
   //              moving = true;
   //          }
   //      }
   //  
   //      if (mouseUp == true && mouseDown == false)
   //      {
   //          moving = false;
   //  
   //          if (Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) <= 0.5f &&
   //              Mathf.Abs(this.transform.localPosition.y - target.transform.localPosition.y) <= 0.5f)
   //          {
   //              this.transform.position = target.transform.localPosition;
   //              finish = true;
   //  
   //              //Destroy(pickup_new.EmptyObj.transform.parent.GetChild(0));
   //              inventory_.isFull[slot_Index] = false; 
   //  
   //              //Debug.Log("inventory: "+inventory_.isFull[slot_index__]);
   //              place_correct = true;
   //  
   //              //transform.parent = null;
   //          }
   //  
   //          else
   //          {
   //              this.transform.position = resetPosition;
   //              transform.localScale = new Vector3((float)pickup_new.object_dimension.x / 2f, (float)pickup_new.object_dimension.y / 2f, pickup_new.object_dimension.z);
   //  
   //              //if(place_correct ==false) inventory_.isFull[slot_index__] = true;
   //  
   //              place_correct = false;
   //          }
   //      }
   //  }
}
