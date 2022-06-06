using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolum_gecme : MonoBehaviour
{
    private bool onenter = false; // mouse bolum geçme kapýsýnýn üstünde mi

    public string sceneName=""; // gidilecek sahnenin adý
    

    

    private void Update()
    {

        // // mouse bolum geçme kapýsýnýn üstünde ve mouse'un sol tuþuna basýlýyorsa sahneyi yükle
        if ( onenter == true && Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(sceneName); // gidilecek sahneyi yükle
        }

        
    }

  

    private void OnMouseEnter()
    {
        
        onenter = true;  // mouse bolum geçme kapýsýnýn üstünde
    }

    private void OnMouseExit()
    {
        
        onenter = false; // mouse bolum geçme kapýsýnýn üstünde deðil
    }
}
