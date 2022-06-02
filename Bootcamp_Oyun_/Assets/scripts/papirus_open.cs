using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papirus_open : MonoBehaviour
{

    private bool onenter = false;
    [SerializeField] GameObject papirusCanvas;

    private AudioSource audioSource_;

    public AudioClip paperSound; // 

    private bool isFirtTime = true;

    private void Start()
    {
        papirusCanvas.gameObject.SetActive(false);

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  // belleðe yazma
        audioSource_.clip = paperSound; // 

        
    }
    private void Update()
    {

        if (onenter == true && isFirtTime == true)
        {

            //audioSource_.Play();
            papirusCanvas.gameObject.SetActive(true);
            isFirtTime = false;

        }

        if (onenter==true && Input.GetMouseButtonDown(0))
        {
            
            audioSource_.Play();
            papirusCanvas.gameObject.SetActive(true);
            
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

    public void papirus_canvas_pasif()
    {
        papirusCanvas.gameObject.SetActive(false);
    }
}
