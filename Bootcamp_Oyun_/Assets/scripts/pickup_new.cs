using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_new : MonoBehaviour
{
    private inventory_new inventory_; // inventory_new içindeki slots'lara ulaþmak için tanýmlandý

    public GameObject pickup_particle; // nesne envantere alýnýrken çýkacak olan particle

    private AudioSource audioSource_;

    public AudioClip pickUp_sound; // nesne envantere alýnýrken çalacak olan audio clip

    private bool isMouseEnter = false; // Mouse nesnenin üzerinde mi

    private bool firstTimeInIventory = true; // nesne ilk defa mý envantere alýnacak
    

    public float inventory_scale=0.5f; // nesnenin envanter içindeki küçülme oraný

    

    private void Awake()
    {
        this.gameObject.GetComponent<drag_movement_new>().enabled = false; // drag_movement_new scriptini baþlangýçta bug olmamasý için kapatýlmasý
        audioSource_ = this.gameObject.GetComponent<AudioSource>();  // belleðe yazma
        audioSource_.clip = pickUp_sound; // //audio source kompanentine audio clip atandý


    }

    private void Start()
    {
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>(); // inventory_new içindeki slots'lara ulaþmak için tanýmlandý
        
        

    }

    private void Update()
    {
        if (firstTimeInIventory == true) // nesne ilk defa envantere alýnacaksa pick_up komutu çalýþtýrýlsýn
        {
            pick_up();
        }
    }

    // nesneyi envantere alma fonksiyonu
    private void pick_up()
    {
        if (isMouseEnter == true) // mouse objenin üzerindeyse çalýþtýr
        {
            if (Input.GetMouseButtonDown(0)) // mouse'un sol tuþuna basýldýysa çalýþtýr
            {
                
                // Envanterdeki tüm slotlara bak ve boþ olan ilk slota alýnacak olan nesneyi gönder

                for (int i = 0; i < inventory_.slots.Length; i++)
                {
                    if (inventory_.isFull[i] == false) // envanter boþ ise nesneyi envantere al
                    {

                        inventory_.isFull[i] = true; // envanter artýk dolu

                        

                        this.gameObject.transform.position = inventory_.slots[i].transform.position; // nesneyi slot'un pozisyonuna atama

                        

                        transform.localScale=transform.localScale * inventory_scale; // nesneyi slot içine sýðdýrmak için küçültme

                        Instantiate(pickup_particle, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);


                        

                        Debug.Log("yeni nesne boyutu " + transform.localScale);


                        firstTimeInIventory = false; // envantere nesne alýndý

                        audioSource_.Play();  // envantere nesne alýrken ses klibini oynat
                        
                        this.gameObject.GetComponent<drag_movement_new>().enabled = true; //drag_movement_new scriptini aktif hale getir
                        break; // döngüyü durdur
                    }
                }
            }

        }
    }

    private void OnMouseEnter()
    {
        isMouseEnter = true; // mouse nesnenn üzerinde
    }

    private void OnMouseExit()
    {
        isMouseEnter = false; // mouse nesnenin üzerinde deðil
    }

    
}
