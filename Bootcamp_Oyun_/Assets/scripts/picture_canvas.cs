using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picture_canvas : MonoBehaviour
{
    private bool onenter = false;
    [SerializeField] GameObject pictureCanvas;

    private AudioSource audioSource_;

    public AudioClip pictureSound; // 

    //private bool isFirtTime = true;

    

    private bool isFirtTimeOpenDoor ;


    private void Start()
    {
        pictureCanvas.gameObject.SetActive(false);

        audioSource_ = this.gameObject.GetComponent<AudioSource>();  // belleðe yazma
        audioSource_.clip = pictureSound; // 
        
        isFirtTimeOpenDoor = true;
    }
    private void Update()
    {

        //if (onenter == true && isFirtTime == true)
        //{
        //
        //    //audioSource_.Play();
        //    papirusCanvas.gameObject.SetActive(true);
        //    isFirtTime = false;
        //
        //}

        if (onenter == true && Input.GetMouseButtonDown(0))
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

    public void picture_canvas_pasif()
    {

        if (isFirtTimeOpenDoor == true)
        {
            door_open.nextSceneDoorOpen = true;
            isFirtTimeOpenDoor = false;
        }

        pictureCanvas.gameObject.SetActive(false);

    }
}
