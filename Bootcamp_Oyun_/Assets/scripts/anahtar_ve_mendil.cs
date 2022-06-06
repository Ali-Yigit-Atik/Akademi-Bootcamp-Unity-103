using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anahtar_ve_mendil : MonoBehaviour
{
    
    // Bu scriptte anahtar ve mendil'in kullanýcýya daha raht gözükmesi için hareket fiziði katýlmýþtýr.
    
    public float speed = 1.0f;  // hýz
    private Vector3 startPosition; // baþlangýç konumu
    
    private Collider2D collider_; // collidor
    public float distance = 2.5f; // mesafe

    private AudioSource audioSource_;
    
    public AudioClip fallingSound;  // nesne býrakýlýrken çýkan ses klibi
    private bool isFirstTimeSound = true; // ses yalnýzca bir defa çalsýn diye boolean üzerinden koþul oluþturalacak

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false; // nesnenin hareket etmesi bitene kadar nesnenin üzerine týklansýn istenmiyor bu yüzden collider kapalý

        audioSource_ = transform.parent.GetChild(1).gameObject.GetComponent<AudioSource>(); // parent üzerinden ses kilibi çalýanacak çünkü kendi audio'sunda daha sonra çalýnmak üzere farklý bir klib var
        audioSource_.clip = fallingSound;  //audio souce kompanentine audio clip atandý
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - startPosition.y) <= distance)  // belirlenmiþ mesafeye gelene kadar hareket et
        {


            transform.Translate(0, speed * Time.deltaTime, 0); // hareket kodu
        }

        if (Mathf.Abs(this.transform.position.y - startPosition.y) >= distance) // belirlenmiþ mesafeye gelindiðinde collider aktif olsun ve ses efekti çalýnsýn
        {
            collider_.enabled = true;
            //StartCoroutine("particle_destroy");

            if (speed < 0 && isFirstTimeSound == true)  //speed < 0 koþulunun anlamý anahtar aþaðýya düþecek ve buradaki sesin yalnýzca anahtarda çalýnmasý isteniyor. 
            {
                audioSource_.Play();
                isFirstTimeSound = false;
            }
        }

        

    }

    
}
