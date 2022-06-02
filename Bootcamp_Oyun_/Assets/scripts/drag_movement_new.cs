using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_movement_new : MonoBehaviour
{
    private inventory_new inventory_; // inventory_new i�indeki slots'lara ula�mak i�in tan�mlad�k
    public GameObject target;  // Nesnenin b�rak�laca�� yer/obje
    //public GameObject drop_particle;
    //ParticleSystem dropParticle;

    private float targetWidth;
    private float targetHeight;
    private Vector3 targetCenter;
    private Vector3 targetWorldPos;

    public float kaymaMiktariX = 0;
    public float kaymaMiktariY = 0;

    private AudioSource audioSource_;
    public AudioClip drop_sound;  // nesne b�rak�l�rken ��kan ses klibi

    private bool firstTimeSound = true;  // Nesne hedefe b�rak�l�rken ��kan b�rakma sesi ilk defa m� oynat�lcacak

    private bool moving;  // nesnenin hareket edeip etmedi�ini ve buna g�re logic olu�tumak i�in olu�turuldu
    private bool finish;  // nesnenin hedefe var�p varmad���n� buna g�re de logic planlamak i�in olu�turuldu

    private GameObject inventory__;

    private float startPosX;  // x ekseninde ta��nacak nesne ile mouse pozisyonu aras�ndaki fark
    private float startPosY;  // y ekseninde ta��nacak nesne ile mouse pozisyonu aras�ndaki fark

    private Vector3 resetPosition; // nesnenin slot i�indeki pozisyonu
    

    private Vector3 gameoObjectScale; //nesnenin slot i�indeki boyutu

    private bool mouseUp = false;  // Mouse tu�u yukar�da m�
    private bool mouseDown = false; // mouse tu�u bas�l� m�

    private bool isOnMouseEnter = false; // mouse ta��nacak olan nesnenin �zerinde mi

    
    private int slotIndex;  // Nesne hangi slot'�n i�inde anlamak i�in yaz�lan variable // ismi de�i�tirildi

    private bool isFirstTime = true; // drop particle ilk defa m� oynat�lacak
    private bool deneme = true;

    private bool isInTarget = false;

    private float inventoryScale;

    private void Start()
    {
        
        resetPosition = this.transform.position; //nesne yanl�� yere b�rak�l�rsa ba�lang�� pozisyonu reset pozisyonu olsun
                                                 //
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>(); // inventory_new i�indeki slots'lara ula�mak i�in tan�mlad�k

        audioSource_ = target.GetComponent<AudioSource>(); // belle�e yaz�ld�
        audioSource_.clip = drop_sound;  //audio souce kompanentine audio clip atand�

        gameoObjectScale = this.gameObject.transform.localScale; // nesne envanter i�indeyken olan boyutu tan�mland�

        inventoryScale = this.gameObject.GetComponent<pickup_new>().inventory_scale; // nesne envanter i�indeyken % ne kadar k���ld��� tan�mland�

        //inventory__ = GameObject.FindGameObjectWithTag("inventory");

        targetWidth = target.GetComponent<Collider2D>().bounds.size.x;
        targetHeight = target.GetComponent<Collider2D>().bounds.size.y;
        targetCenter = target.GetComponent<Collider2D>().bounds.center;
        Debug.Log(targetCenter+"  jjj");


        // ta��nabilir nesnenin hangi slot'a gitti�ini bulmak
        for (int i = 0; i <= inventory_.slots.Length - 1; i++)
        {
            if (this.gameObject.transform.position == inventory_.slots[i].transform.position )
            {
                this.slotIndex = i;
            }
        }


    }

    private void Update()
    {

        
        // ta��nabilir nesnenin hangi slot'a gitti�ini bulmak

        //for (int i = 0; i <= inventory_.slots.Length - 1; i++)
        //{
        //    if (this.gameObject.transform.position == inventory_.slots[i].transform.position && this.isOnMouseEnter == true)
        //    {
        //        this.slotIndex = i;
        //    }
        //}

        // Slot i�indeki objeler child obje de�il yani slot'larla beraber hareket etmiyor bundan dolay� slotlar�n ve kameran�n yapt��� pozisyon de�i�imini 
        // ta��nabilir objelere aktaran kodlar:

        if (this.finish == false)
        {
            if (Right_Move1.onenter == true && Right_Move1.isRightMove == true && Right_Move1.rightArrowPosition < Right_Move1.rightWallPosition)
            {
                
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + Right_Move1.rigthMovement, this.gameObject.transform.position.y); //Local'leri world position'a �evirdim
                resetPosition = this.transform.position;  
            }
            else if (left_move.onenter == true && left_move.isLeftMove == true && left_move.leftArrowPosition > left_move.leftWallPosition)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + left_move.leftMovement, this.gameObject.transform.position.y); //Local'leri world position'a �evirdim
                resetPosition = this.transform.position;  
            }
        }


        // Ta��nabilir objelerin pozisyonunun mouse pozisyonu ile e�lenmesi 
        if (this.finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
                
            }
        }

        
        // Nesne ta��ma kodunu �al��t�r�yoruz:

        mouseUp_And_down();




        //if (this.isInTarget == true)  //
        //{
        //    StartCoroutine(this.drop_particle_effect()); //
        //}  // 

        //if(this.finish == true && this.isOnMouseEnter == false)
        //{
        //    this.gameObject.GetComponent<drag_movement_new>().enabled = false;
        //}

        //drop_particle_effect();


    }
    



    private void OnMouseDown()
    {
        this.mouseUp = false;
        this.mouseDown = true;
        
    }

    private void OnMouseUp()
    {

        this.mouseUp = true;
        this.mouseDown = false;

        
    }


    private void OnMouseEnter()
    {
        this.isOnMouseEnter = true;
    }

    private void OnMouseExit()
    {
        this.isOnMouseEnter = false;
    }

   //private IEnumerator drop_particle_effect()  // 
   //{
   //    
   //    yield return new WaitForSeconds(1.5f); // 
   //
   //    this.isInTarget = false; //
   //
   //
   //    // if (this.drop_particle.activeSelf && this.isOnMouseEnter == true && this.mouseDown == true && this.mouseUp == false)
   //    // {
   //    //     //this.drop_particle.SetActive(false);
   //    //     //this.isInTarget = false;
   //    //     Debug.Log("IEnumerator �al��d� xx");
   //    //     this.drop_particle.SetActive(false);
   //    // }
   //
   //
   //}


    // Nesne ta��ma fonksiyonu:

    void mouseUp_And_down()
    {
        

        this.gameObject.GetComponent<pickup_new>().enabled = false;  //Burada pickup_new scripti etkisiz hale getirildi bug olmamas� i�in



        // Objenin �zerine t�kland���nda objen pozisyonunun mouse pozisyonu ile aras�ndaki fark�n� alan ve objenin yer de�i�tirdi�ini(this.moving = true diyerek)
        // haber veren kodlar:

        if (this.isOnMouseEnter == true && this.mouseDown == true && this.mouseUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {

                
                //A�a��daki sat�r. nesne slottan ��kt���nda nesnenin eski boyutuna d�nme kodu:
                this.gameObject.transform.localScale = new Vector3(gameoObjectScale.x/ inventoryScale, gameoObjectScale.y / inventoryScale, gameoObjectScale.z);

                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                this.moving = true; // update fonksiyonun i�inde bu boolean ile yap�lan yer de�i�tirme logic'i var.
            }

            //if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 0.5f &&  // Local'leri world position'a �evirdim
            //    Mathf.Abs(this.transform.position.y - target.transform.position.y) <= 0.5f) // Local'leri world position'a �evirdim
            //{
            //    if (this.isFirstTime == true)
            //    {
            //        Instantiate(this.drop_particle, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
            //        this.isFirstTime = false;
            //        
            //        deneme = false;
            //
            //    }
            //    this.drop_particle.SetActive(true);
            //
            //    
            //    this.isInTarget = true;
            //
            //
            //
            //}

            //else if (Mathf.Abs(this.transform.position.x - target.transform.position.x) > 0.5f &&  // Local'leri world position'a �evirdim
            //        Mathf.Abs(this.transform.position.y - target.transform.position.y) > 0.5f) // Local'leri world position'a �evirdim
            //{
            //    if (this.isInTarget = false && drop_particle.activeSelf && this.gameObject.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>()) == false) 
            //    { 
            //        drop_particle.SetActive(false);
            //        //Invoke("deneme_", 1);
            //        //deneme = true;
            //    }
            //}
        }


        //Nesne do�ru yere yerle�mi�se oldu�u yerde kals�n yada do�ru yere yerle�memi�se envantere geri d�ns�n kodlar�:

        if (this.mouseUp == true && this.mouseDown == false)
        {
            this.moving = false;

            //(Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 0.5f &&  
            //Mathf.Abs(this.transform.position.y - target.transform.position.y) <= 0.5f) 
            

                // Nesne do�ru yerde ise nesne target'e b�rak�ls�n kodlar�:

                if (Mathf.Abs(this.transform.position.x - targetCenter.x) <= targetWidth/1.5 &&  
                Mathf.Abs(this.transform.position.y - targetCenter.y) <=  targetHeight/1.5 ) 
            {

                this.gameObject.transform.position = new Vector3(targetCenter.x + kaymaMiktariX, targetCenter.y + kaymaMiktariY, targetCenter.z);



                //transform.parent = null;


                if (firstTimeSound == true)  // nesne b�rakma esnas�nda yaln�zca bir kez ses oynas�n.
                {
                    audioSource_.Play(); //
                    firstTimeSound = false;
                }

                

                if (this.isOnMouseEnter == true && this.finish == true)  // slot'lar bo�ald� m�? komutu
                {
                    Debug.Log(this.slotIndex);
                    inventory_.isFull[this.slotIndex] = false;
                }

                if (this.gameObject.transform.childCount == 2)   // Game objenin i�indeki ipucu i�aretlerini silme ve particle effecti setactive(false) yapma
                {
                    Debug.Log("child var");
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false); // 

                }

                if (this.target.transform.childCount == 1) // target obejenin i�indeki ipucu i�aretlerini silme
                {

                    Destroy(this.target.transform.GetChild(0).gameObject);
                }

                this.finish = true; //burda bir boolean yard�myla hareket logic kurulmu�tu. Nesne yerine vard���na g�re nesnenin mouse dan etkilenmemesi i�in
                                    // finish true yap�ld�

            }

            // Nesne do�ru yere b�rak�lmam��sa envantere geri d�ns�n kodlar�:
            else
            {
                this.transform.position = resetPosition;
                
                transform.localScale = gameoObjectScale; //Nesne envantere geri d�nd���nde envanterin i�ine s��mas� i�in tekrar k���ls�n

                             

                this.finish = false;  // nesne do�ru yere ula�mad� harekete devam etsin logic ba�lant�s�
                                
            }
        }
    }


    void deneme_()
    {
        deneme = false;
    }

    
   
}
