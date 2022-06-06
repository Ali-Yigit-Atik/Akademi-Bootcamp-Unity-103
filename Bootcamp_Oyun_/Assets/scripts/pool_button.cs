using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool_button : MonoBehaviour
{
    
    // havuzdan asansör düðmesi yükselerek çýkmasý için yazdýlan kodlar
    
    
    private float speed = 1.5f; // hýz
    private Vector3 startPosition; // baþlangýç pozisyonu
    private ParticleSystem ps;   // oynatýcalak particle systemin komponentinin atanacak variable
    private Collider2D collider_; 
    public float distance = 2.5f; // asansör düðmesinin yukaru yükselme miktarý

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
        collider_ = this.gameObject.GetComponent<Collider2D>();
        collider_.enabled = false; // asansör düðmesi en yüksek mesafeye ulaþana kadar üzerine dokunulmasýn yani envantere alýnmasýn
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y - startPosition.y) <= distance)  // düðme istenilen mesafeyi kat edene kadar hareket etsin
        {


            transform.Translate(0, speed * Time.deltaTime, 0);   
        }

        if (Mathf.Abs(this.transform.position.y - startPosition.y) >= distance)  // belirlenmiþ mesafeye gelindiðinde collider aktif olsun ve particle efekt oynasýn
        {
            collider_.enabled = true;
            StartCoroutine("particle_destroy"); // Particle efekt loop içinde obje envantere girdiðinde de oynamamasý için particle efekti pasif hale getericek
                                                // fonksiyonun çalýþtýrýlmasý
        }
        
        
    }

    IEnumerator particle_destroy()
    {
        if (this.gameObject.transform.childCount > 0)
        {
            for(int i =0; i<= this.gameObject.transform.childCount-1; i++)
            {
                if(this.gameObject.transform.GetChild(i).gameObject.tag == "loop particle")  // pasif hale gelecek olan particle'ýn bulunmasý
                {
                    ps = this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
                    var main = ps.main;

                    

                    yield return new WaitForSeconds(1); // Particle efekt, asansör düðmesi en yükseðe gelsede 1 saniye daha oynasýn bu þekilde daha güzel gözüküyor
                                                        // Bu yüzden update fonksiyonu içinde deðilde IEnumerator içinde pasif hale getirme iþlemi yapýldý

                    //Destroy(this.gameObject.transform.GetChild(i).gameObject);
                    
                    main.loop = false; // particle'ýn loop'tan çýkarýlmasý

                    this.gameObject.GetComponent<pool_button>().enabled = false;
                    break;
                }
            }
        }
    }
}
