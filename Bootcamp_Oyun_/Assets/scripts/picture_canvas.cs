using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picture_canvas : MonoBehaviour
{
    private bool onenter = false; // mouse bu game objeninin üzerinde mi deðil mi diye kontrol edilecek
    [SerializeField] GameObject pictureCanvas; // aktive edilecek olan resim canvasý

    private AudioSource audioSource_;

    public AudioClip pictureSound; // resim açýlýrken çalacak olan ses klibi

    //private bool isFirtTime = true;



    private bool isFirtTimeOpenDoor ; // Resim açýldðýnda ayný zamanda diðer sahneye geçiþ kapýsada açýlacak. Kapý ilk defa mý açýlacak kontrol boolean'ý


    private void Start()
    {
        pictureCanvas.gameObject.SetActive(false);  // resim baþlangýçta kapalý olsun

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = pictureSound; // ses klibi atandý
        
        isFirtTimeOpenDoor = true;
    }
    private void Update()
    {

        

        if (onenter == true && Input.GetMouseButtonDown(0))  // scriptin bulunduðu nesnenin üzerine týklandýðýnda resim açýlsýn ve ses klibi çalýnsýn
        {

            audioSource_.Play();
            pictureCanvas.gameObject.SetActive(true);

            

        }
    }

    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin iþaretinin üzerinde
    }

    private void OnMouseExit()
    {

        onenter = false;  // mouse nesnenin üzerinde deðil
    }

    public void picture_canvas_pasif()   // resim canvasýnýn içinde ki panele button komponenti atandý bu panele týklandýðýnda canvas kapanýyor
    {

        if (isFirtTimeOpenDoor == true) // sonraki bölüme geçiþ kapýsý aktive edilsin
        {
            door_open.nextSceneDoorOpen = true;
            isFirtTimeOpenDoor = false;
        }

        pictureCanvas.gameObject.SetActive(false);

    }
}
