using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_movement_new : MonoBehaviour
{

    // Bu scriptte nesnelerin sürükle-býrak mekaniðinin kodlarý ve nesne doðru yerde mi deðil mi diye kontrol eden kodlar var
    // (Not: Aþaðýda yorum þekline alýnmýþ bazý kodlar var. Bu koddar henüz tamamlanmamýþ particle sistem initiate etmek ve initiate edilen particel sistemin
    // sürüklenen nesne doðru yere yaklaþtýðýnda çalýþmasýný uzaklaþtýðýnda da kapanmasýný içeren kodlarýn denemesidir.)



    private inventory_new inventory_; // inventory_new içindeki slots'lara ulaþmak için tanýmladýk
    public GameObject target;  // Nesnenin býrakýlacaðý yer/obje
    //public GameObject drop_particle;
    //ParticleSystem dropParticle;

    private float targetWidth; // target nesnenin geniþliði
    private float targetHeight; // target nesnenin yüksekliði
    private Vector3 targetCenter; // targetin pozisyonu 
    

    public float kaymaMiktariX = 0; // nesneleri hedef obejenin istenilen yerine býrakmasýný saðlamak için oluþturulmuþ kayma miktarý
    public float kaymaMiktariY = 0; // nesneleri hedef obejenin istenilen yerine býrakmasýný saðlamak için oluþturulmuþ kayma miktarý

    private AudioSource audioSource_;
    private AudioSource audioSource2_; //  setactive(false) olacak targetler var bu durumda ses çýkarabilmek için targetlerin ebeveyn objeleri üzerinden ses çalýnacak
    public AudioClip drop_sound;  // nesne býrakýlýrken çýkan ses klibi

    private bool firstTimeSound = true;  // Nesne hedefe býrakýlýrken çýkan býrakma sesi ilk defa mý oynatýlcacak

    private bool moving;  // nesnenin hareket edeip etmediðini ve buna göre logic oluþtumak için oluþturuldu
    private bool finish;  // nesnenin hedefe varýp varmadýðýný buna göre de logic planlamak için oluþturuldu

    private GameObject inventory__;

    private float startPosX;  // x ekseninde taþýnacak nesne ile mouse pozisyonu arasýndaki fark
    private float startPosY;  // y ekseninde taþýnacak nesne ile mouse pozisyonu arasýndaki fark

    private Vector3 resetPosition; // nesnenin slot içindeki pozisyonu
    

    private Vector3 gameoObjectScale; //nesnenin slot içindeki boyutu

    private bool mouseUp = false;  // Mouse tuþu yukarýda mý
    private bool mouseDown = false; // mouse tuþu basýlý mý

    private bool isOnMouseEnter = false; // mouse taþýnacak olan nesnenin üzerinde mi

    
    private int slotIndex;  // Nesne hangi slot'ýn içinde anlamak için yazýlan variable // ismi deðiþtirildi

    private bool isFirstTime = true; // drop particle ilk defa mý oynatýlacak
    private bool deneme = true;

    private bool isInTarget = false;

    private float inventoryScale; // nesnelerin envanterdeki boyut deðiþim oraný

    private bool isInSlot =true; // nesne envanter de mi boolean'ý
    private bool isNeedDestroy = false; // Bazý nesneler hedefe vardýktan sonra ortadan kaybolmalý 

    private void Start()
    {
        
        resetPosition = this.transform.position; //nesne yanlýþ yere býrakýlýrsa baþlangýç pozisyonu reset pozisyonu olsun
                                                 //
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>(); // inventory_new içindeki slots'lara ulaþmak için tanýmladýk

        audioSource_ = target.GetComponent<AudioSource>(); // belleðe yazýldý
        audioSource_.clip = drop_sound;  //audio souce kompanentine audio clip atandý

        if (target.gameObject.CompareTag("komidin")  || target.gameObject.CompareTag("resim")) // hedef objelerin ebeveynine ses klibi atandý
        {
                        
            audioSource2_ = target.transform.parent.gameObject.GetComponent<AudioSource>(); // belleðe yazýldý
            audioSource2_.clip = drop_sound;
            
        }

        gameoObjectScale = this.gameObject.transform.localScale; // nesne envanter içindeyken olan boyutu tanýmlandý

        inventoryScale = this.gameObject.GetComponent<pickup_new>().inventory_scale; // nesne envanter içindeyken % ne kadar küçüldüðü tanýmlandý

        

        targetWidth = target.GetComponent<Collider2D>().bounds.size.x;
        targetHeight = target.GetComponent<Collider2D>().bounds.size.y;
        targetCenter = target.GetComponent<Collider2D>().bounds.center;
        

        if (target.gameObject.CompareTag("pool"))
        {
            targetWidth = targetWidth * (1.5f / 2f); // daha iyi bir yerleþtirme kontrolü için bu oran yapýldý
            targetHeight = targetHeight * (1.5f / 2f); // daha iyi bir yerleþtirme kontrolü için bu oran yapýldý
        }

        // taþýnabilir nesnenin hangi slot'a gittiðini bulmak
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

        
        

        // Slot içindeki objeler child obje deðil yani slot'larla beraber hareket etmiyor bundan dolayý slotlarýn ve kameranýn yaptýðý pozisyon deðiþimini 
        // taþýnabilir objelere aktaran kodlar:

        if (this.finish == false)
        {
            if (Right_Move1.onenter == true && Right_Move1.isRightMove == true && Right_Move1.rightArrowPosition < Right_Move1.rightWallPosition)
            {
                
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + Right_Move1.rigthMovement, this.gameObject.transform.position.y); //Local'leri world position'a çevirdim
                resetPosition = this.transform.position;  
            }
            else if (left_move.onenter == true && left_move.isLeftMove == true && left_move.leftArrowPosition > left_move.leftWallPosition)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + left_move.leftMovement, this.gameObject.transform.position.y); //Local'leri world position'a çevirdim
                resetPosition = this.transform.position;  
            }
        }


        // Taþýnabilir objelerin pozisyonunun mouse pozisyonu ile eþlenmesi 
        if (this.finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
                
            }
        }

        
        // Nesne taþýma kodunu çalýþtýrýyoruz:

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
   //    //     Debug.Log("IEnumerator çalýþdý xx");
   //    //     this.drop_particle.SetActive(false);
   //    // }
   //
   //
   //}


    // Nesne taþýma fonksiyonu:

    void mouseUp_And_down()
    {
        

        this.gameObject.GetComponent<pickup_new>().enabled = false;  //Burada pickup_new scripti etkisiz hale getirildi bug olmamasý için



        // Objenin üzerine týklandýðýnda obje pozisyonunun mouse pozisyonu ile arasýndaki farkýný alan ve objenin yer deðiþtirdiðini(this.moving = true diyerek)
        // haber veren kodlar:

        if (this.isOnMouseEnter == true && this.mouseDown == true && this.mouseUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {

                
                //Aþaðýdaki satýr. nesne slottan çýktýðýnda nesnenin eski boyutuna dönme kodu:
                this.gameObject.transform.localScale = new Vector3(gameoObjectScale.x/ inventoryScale, gameoObjectScale.y / inventoryScale, gameoObjectScale.z);

                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                this.moving = true; // update fonksiyonun içinde bu boolean ile yapýlan yer deðiþtirme logic'i var.
            }

            // Aþaðýda particle efektin deneme kodlarý var(henüz hazýr deðil)
            
            //if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 0.5f &&  // Local'leri world position'a çevirdim
            //    Mathf.Abs(this.transform.position.y - target.transform.position.y) <= 0.5f) // Local'leri world position'a çevirdim
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

            //else if (Mathf.Abs(this.transform.position.x - target.transform.position.x) > 0.5f &&  
            //        Mathf.Abs(this.transform.position.y - target.transform.position.y) > 0.5f) 
            //{
            //    if (this.isInTarget = false && drop_particle.activeSelf && this.gameObject.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>()) == false) 
            //    { 
            //        drop_particle.SetActive(false);
            //        //Invoke("deneme_", 1);
            //        //deneme = true;
            //    }
            //}
        }


        //Nesne doðru yere yerleþmiþse olduðu yerde kalsýn yada doðru yere yerleþmemiþse envantere geri dönsün kodlarý:

        if (this.mouseUp == true && this.mouseDown == false)
        {
            this.moving = false;

             
            

                // Nesne doðru yerde ise nesne target'e býrakýlsýn kodlarý:

                if (Mathf.Abs(this.transform.position.x - targetCenter.x) <= targetWidth/1.5 &&  
                Mathf.Abs(this.transform.position.y - targetCenter.y) <=  targetHeight/1.5 ) 
            {

                this.gameObject.transform.position = new Vector3(targetCenter.x + kaymaMiktariX, targetCenter.y + kaymaMiktariY, targetCenter.z);


                if (target.gameObject.CompareTag("komidin") == false && target.gameObject.CompareTag("resim") == false && firstTimeSound == true)  // nesne býrakma esnasýnda yalnýzca bir kez ses oynasýn.
                {
                    audioSource_.Play(); //
                    firstTimeSound = false;
                }

                

                if (target.gameObject.CompareTag("komidin") && this.finish == false) 
                {
                    isNeedDestroy = true;
                    Komidin.komidinOpened = true;

                    audioSource2_.Play();
                    
                }

                if (target.gameObject.CompareTag("resim") && this.finish == false)
                {
                    isNeedDestroy = true;
                    resim.pictureOpened = true;

                    
                    audioSource2_.Play();
                }

                if (target.gameObject.CompareTag("tables") && this.finish == false)
                {
                    papirus_puzzle_open.totalCoffeePuzzleSolved = papirus_puzzle_open.totalCoffeePuzzleSolved + 1;
                }

                if (target.gameObject.CompareTag("button") && this.finish == false )
                {
                    Elevator_open.totalButtonSolved = Elevator_open.totalButtonSolved + 1;
                }

                if(target.gameObject.CompareTag("button") && this.finish == false &&  this.gameObject.transform.childCount == 3)
                {
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                }

               

                

                

                if (this.gameObject.transform.childCount == 2)   // Game objenin içindeki ipucu iþaretlerini silme ve particle effecti setactive(false) yapma
                {
                    Debug.Log("child var");
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false); // 

                }

                if (this.target.transform.childCount == 1) // target obejenin içindeki ipucu iþaretlerini silme
                {

                    Destroy(this.target.transform.GetChild(0).gameObject);
                }

                this.finish = true; //burda bir boolean yardýmyla hareket logic kurulmuþtu. Nesne yerine vardýðýna göre nesnenin mouse dan etkilenmemesi için
                                    // finish true yapýldý

                if (isInSlot == true && this.finish == true)  // slot'lar boþaldý mý? komutu // eski logic: if(this.isOnMouseEnter == true && && this.finish == true)
                {
                    Debug.Log(this.slotIndex);
                    inventory_.isFull[this.slotIndex] = false;
                    isInSlot = false;
                    
                }

                if(isNeedDestroy == true)
                {
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                }
            }

            // Nesne doðru yere býrakýlmamýþsa envantere geri dönsün kodlarý:
            else
            {
                this.transform.position = resetPosition; // nesneyi envantere geri koyma
                
                transform.localScale = gameoObjectScale; //Nesne envantere geri döndüðünde envanterin içine sýðmasý için tekrar küçülsün

                             

                this.finish = false;  // nesne doðru yere ulaþmadý harekete devam etsin logic baðlantýsý
                                
            }
        }
    }


    

    
   
}
