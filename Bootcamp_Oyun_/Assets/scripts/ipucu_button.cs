using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipucu_button : MonoBehaviour
{
    
    public GameObject[] tips_image; // tips imagelerinin inspector da atanmasý için public game object dizisi oluþturuldu
    
    private bool onenter = false; // mouse tips butonunun üstünde mi
    public float normalSize = 4f;
    public float onPressSize = 5.5f;
    

    private void Update()
    {
        
        // Eðer mosue tips butonunnun üstünde ve basýlýysa sahnedeki tips iþaretlerini göster
        if (onenter && Input.GetMouseButton(0))
        {
            for(int i =0; i<=tips_image.Length-1; i++)
            {
                
                if(tips_image[i] != null) // nesneler targetlere konduðu zaman tips iþaterleri siliniyor.
                                          // Döngüde hata almamak için if koþulu kondu ve null deðilse þartý eklendi
                {
                    tips_image[i].SetActive(true);
                }
            }
        }

        // mouse basýlmadýðý zaman tips iþaretleri pasif halde kalsýn kodlarý:
        else if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i <= tips_image.Length - 1; i++)
            {
                
                if (tips_image[i] != null)// nesneler targetlere konduðu zaman tips iþaterleri siliniyor.
                                          // Döngüde hata almamak için if koþulu kondu ve null deðilse þartý eklendi
                {
                    tips_image[i].SetActive(false);
                }
            }
        }
    }
    
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(onPressSize, onPressSize, 1);  // mouse tips butonunun üzerindeyken buton büyüsün
        onenter = true; // mouse tips butonunun üstünde
    }
    
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(normalSize, normalSize, 1); // mouse tips butonunun üzerinde deðilken buton eski haline dönsün
        onenter = false;  // mouse tips butonunun üstünde deðil
    }
}
