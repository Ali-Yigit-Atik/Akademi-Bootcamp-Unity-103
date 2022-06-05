using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anahtar_ve_mendil : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 startPosition;
    //private ParticleSystem ps;
    private Collider2D collider_;
    public float distance = 2.5f; //

    private AudioSource audioSource_;
    
    public AudioClip fallingSound;  // nesne býrakýlýrken çýkan ses klibi
    private bool isFirstTimeSound = true;

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false;

        audioSource_ = transform.parent.GetChild(1).gameObject.GetComponent<AudioSource>(); // kardeþi üzerinden ses kilibi çaýlanacak çünkü kendi audio'sunda baþka zaman çalýnmak üzere farklý bir klib var
        audioSource_.clip = fallingSound;  //audio souce kompanentine audio clip atandý
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - startPosition.y) <= distance)
        {


            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Mathf.Abs(this.transform.position.y - startPosition.y) >= distance)
        {
            collider_.enabled = true;
            //StartCoroutine("particle_destroy");

            if (speed < 0 && isFirstTimeSound == true)
            {
                audioSource_.Play();
                isFirstTimeSound = false;
            }
        }

        

    }

    
}
