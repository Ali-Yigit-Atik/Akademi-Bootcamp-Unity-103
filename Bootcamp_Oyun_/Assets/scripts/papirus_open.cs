using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papirus_open : MonoBehaviour
{

    private bool onenter = false; // mouse bu game objeninin üzerinde mi deðil mi diye kontrol edilecek
    [SerializeField] GameObject papirusCanvas; // aktive edilecek olan papirus canvas

    private AudioSource audioSource_;

    public AudioClip paperSound; // papirus açýlýrken çalacak olan ses klibi

    

    private void Start()
    {
        papirusCanvas.gameObject.SetActive(false); // papirus baþlangýçta kapalý olsun

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = paperSound; // ses klibi atama

        
    }
    private void Update()
    {

        

        if (onenter==true && Input.GetMouseButtonDown(0)) // scriptin bulunduðu nesnenin üzerine týklandýðýnda papirus açýlsýn ve ses klibi çalýnsýn
        {
            
            audioSource_.Play();
            papirusCanvas.gameObject.SetActive(true);
            
        }
    }

    private void OnMouseEnter()
    {
        
        onenter = true; // mouse nesnenin  üzerinde
    }

    private void OnMouseExit()
    {
        
        onenter = false;  // mouse nesnenin üzerinde deðil
    }

    public void papirus_canvas_pasif() // papirus canvasýn içinde ki panele button komponenti atandý bu panele týklandýðýnda canvas kapanýyor
    {
        papirusCanvas.gameObject.SetActive(false);
    }
}
