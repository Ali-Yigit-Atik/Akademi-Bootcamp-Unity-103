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
    
    public AudioClip fallingSound;  // nesne b�rak�l�rken ��kan ses klibi
    private bool isFirstTimeSound = true;

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false;

        audioSource_ = transform.parent.GetChild(1).gameObject.GetComponent<AudioSource>(); // karde�i �zerinden ses kilibi �a�lanacak ��nk� kendi audio'sunda ba�ka zaman �al�nmak �zere farkl� bir klib var
        audioSource_.clip = fallingSound;  //audio souce kompanentine audio clip atand�
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

    //IEnumerator particle_destroy()
    //{
    //    if (this.gameObject.transform.childCount > 0)
    //    {
    //        for (int i = 0; i <= this.gameObject.transform.childCount - 1; i++)
    //        {
    //            if (this.gameObject.transform.GetChild(i).gameObject.tag == "loop particle")
    //            {
    //                ps = this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
    //                var main = ps.main;
    //
    //
    //
    //                yield return new WaitForSeconds(1);
    //                //Destroy(this.gameObject.transform.GetChild(i).gameObject);
    //
    //                main.loop = false;
    //
    //                this.gameObject.GetComponent<pool_button>().enabled = false;
    //                break;
    //            }
    //        }
    //    }
    //}
}
