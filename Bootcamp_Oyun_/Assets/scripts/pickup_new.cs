using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_new : MonoBehaviour
{
    private inventory_new inventory_; // inventory_new i�indeki slots'lara ula�mak i�in tan�mland�

    public GameObject pickup_particle; // nesne envantere al�n�rken ��kacak olan particle

    private AudioSource audioSource_;

    public AudioClip pickUp_sound; // nesne envantere al�n�rken �alacak olan audio clip

    private bool isMouseEnter = false; // Mouse nesnenin �zerinde mi

    private bool firstTimeInIventory = true; // nesne ilk defa m� envantere al�nacak
    

    public float inventory_scale=0.5f; // nesnenin envanter i�indeki k���lme oran�

    //public static Vector3 object_dimension;

    //public static int slot_Index;

    //private pickup_new pickUp; //

    //private GameObject player_;

    private void Awake()
    {
        this.gameObject.GetComponent<drag_movement_new>().enabled = false; // drag_movement_new scriptini ba�lang��ta bug olmamas� i�in kapat�lmas�
        audioSource_ = this.gameObject.GetComponent<AudioSource>();  // belle�e yazma
        audioSource_.clip = pickUp_sound; // //audio source kompanentine audio clip atand�


    }

    private void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>(); // inventory_new i�indeki slots'lara ula�mak i�in tan�mland�
        
        //pickUp = GetComponent<pickup_new>(); //

        //object_dimension = new Vector3((float) transform.localScale.x, (float)transform.localScale.y, transform.localScale.z);

        //Debug.Log("nesne boyutu "+object_dimension);

        //player_= GameObject.FindGameObjectWithTag("player");

    }

    private void Update()
    {
        if (firstTimeInIventory == true) // nesne ilk defa envantere al�nacaksa pick_up komutu �al��t�r�ls�n
        {
            pick_up();
        }
    }

    // nesneyi envantere alma fonksiyonu
    private void pick_up()
    {
        if (isMouseEnter == true) // mouse objenin �zerindeyse �al��t�r
        {
            if (Input.GetMouseButtonDown(0)) // mouse'un sol tu�una bas�ld�ysa �al��t�r
            {
                
                // Envanterdeki t�m slotlara bak ve bo� olan ilk slota al�nacak olan nesneyi g�nder

                for (int i = 0; i < inventory_.slots.Length; i++)
                {
                    if (inventory_.isFull[i] == false) // envanter bo� ise nesneyi envantere al
                    {

                        inventory_.isFull[i] = true; // envanter art�k dolu

                        //slot_Index = i;

                        //this.gameObject.transform.SetParent(inventory_.slots[i].transform);
                        //transform.TransformPoint(Vector3.zero);

                        this.gameObject.transform.position = inventory_.slots[i].transform.position; // nesneyi slot'un pozisyonuna atama

                        //Instantiate(itemButton, inventory_.slots[i].transform.position, Quaternion.identity, inventory_.slots[i].transform);

                        //transform.localScale = new Vector3((float) object_dimension.x * 0.5f, (float) object_dimension.y *0.5f, object_dimension.z);

                        transform.localScale=transform.localScale * inventory_scale; // nesneyi slot i�ine s��d�rmak i�in k���ltme

                        Instantiate(pickup_particle, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);


                        //this.gameObject.transform.SetParent(player_.transform); gerek kalmad�

                        Debug.Log("yeni nesne boyutu " + transform.localScale);


                        firstTimeInIventory = false; // envantere nesne al�nd�

                        audioSource_.Play();  // envantere nesne al�rken ses klibini oynat
                        
                        this.gameObject.GetComponent<drag_movement_new>().enabled = true; //drag_movement_new scriptini aktif hale getir
                        break; // d�ng�y� durdur
                    }
                }
            }

        }
    }

    private void OnMouseEnter()
    {
        isMouseEnter = true;
    }

    private void OnMouseExit()
    {
        isMouseEnter = false;
    }

    
}
