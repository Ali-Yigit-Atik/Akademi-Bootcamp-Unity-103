using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_new : MonoBehaviour
{
    private inventory_new inventory_;

    public GameObject pickup_particle;

    private AudioSource audioSource_;

    public AudioClip pickUp_sound;

    private bool mouse_enter = false;

    private bool firstTimeInIventory = true; //
    //public Texture2D selftexture;

    public static Vector3 object_dimension;

    public static int slot_Index;

    private pickup_new pickUp; //

    private void Awake()
    {
        this.gameObject.GetComponent<drag_movement_new>().enabled = false;
        audioSource_ = this.gameObject.GetComponent<AudioSource>(); // 
        audioSource_.clip = pickUp_sound; //


    }

    private void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();
        pickUp = GetComponent<pickup_new>(); //

        object_dimension = new Vector3((float) transform.localScale.x, (float)transform.localScale.y, transform.localScale.z);

        Debug.Log("nesne boyutu "+object_dimension);

        

    }

    private void Update()
    {
        if (firstTimeInIventory == true)
        {
            pick_up();
        }
    }

    private void pick_up()
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

                        slot_Index = i;

                        //this.gameObject.transform.SetParent(inventory_.slots[i].transform);
                        //transform.TransformPoint(Vector3.zero);

                        this.gameObject.transform.position = inventory_.slots[i].transform.position;

                        //Instantiate(itemButton, inventory_.slots[i].transform.position, Quaternion.identity, inventory_.slots[i].transform);

                        transform.localScale = new Vector3((float) object_dimension.x / 2f, (float) object_dimension.y/ 2f, object_dimension.z);


                        Instantiate(pickup_particle, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);

                        
                        Debug.Log("yeni nesne boyutu " + transform.localScale);


                        firstTimeInIventory = false;

                        audioSource_.Play();  //
                        
                        this.gameObject.GetComponent<drag_movement_new>().enabled = true;
                        break;
                    }
                }
            }

        }
    }

    private void OnMouseEnter()
    {
        mouse_enter = true;
    }

    private void OnMouseExit()
    {
        mouse_enter = false;
    }

    
}
