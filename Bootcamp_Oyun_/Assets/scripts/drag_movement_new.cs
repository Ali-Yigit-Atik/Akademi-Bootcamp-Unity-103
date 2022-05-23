using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_movement_new : MonoBehaviour
{
    private inventory_new inventory_;
    public GameObject target;
    public GameObject drop_particle;
    ParticleSystem dropParticle;

    private AudioSource audioSource_;
    public AudioClip drop_sound;

    private bool firstTimeSound = true;

    private bool moving;
    private bool finish;

    private GameObject inventory__;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
    private Vector3 mousePos_local;

    private bool mouseUp = false;
    private bool mouseDown = false;

    private bool isOnMouseEnter = false;

    private bool place_correct = false;

    private int Slot_index_;

    private bool isFirsTime = true;
    private bool deneme = true;

    private bool isInTarget = false;

    private void Start()
    {
        //resetPosition = this.transform.localPosition;
        resetPosition = this.transform.position;
        inventory_ = GameObject.FindGameObjectWithTag("player").GetComponent<inventory_new>();

        audioSource_ = target.GetComponent<AudioSource>(); // 
        audioSource_.clip = drop_sound; //





        //inventory__ = GameObject.FindGameObjectWithTag("inventory");
    }

    private void Update()
    {

        // taþýnabilir nesnenin hangi slot'a gittiðini bulmak

        // if (this.gameObject.transform.position == inventory_.slots[0].transform.position && this.isOnMouseEnter == true) 
        // {
        //     this.Slot_index_ = 0;
        // }
        // else if (this.gameObject.transform.position == inventory_.slots[1].transform.position && this.isOnMouseEnter == true)
        // {
        //     this.Slot_index_ = 1;
        // }
        // else if (this.gameObject.transform.position == inventory_.slots[2].transform.position && this.isOnMouseEnter == true)
        // {
        //     this.Slot_index_ = 2;
        // }
        // else if (this.gameObject.transform.position == inventory_.slots[3].transform.position && this.isOnMouseEnter == true)
        // {
        //     this.Slot_index_ = 3;
        // }


        // taþýnabilir nesnenin hangi slot'a gittiðini bulmak(yukarýdaki kodu for döngüsüyle yazdým bu kod daha iyi) 

        for (int i = 0; i <= inventory_.slots.Length - 1; i++)
        {
            if (this.gameObject.transform.position == inventory_.slots[i].transform.position && this.isOnMouseEnter == true)
            {
                this.Slot_index_ = i;
            }
        }

        //if (this.isOnMouseEnter == true && this.finish == true)  // slot'lar boþaldý mý? komutu
        //{ 
        //    Debug.Log(this.Slot_index_); 
        //    inventory_.isFull[this.Slot_index_] = false; 
        //}

        if (Right_Move1.isRightMove == true)
        {
            //this.gameObject.transform.localPosition= new Vector3(this.gameObject.transform.localPosition.x + Right_Move1.rigthMovement, this.gameObject.transform.localPosition.y);
            //resetPosition = this.transform.localPosition;

            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + Right_Move1.rigthMovement, this.gameObject.transform.position.y); //Local'leri world position'a çevirdim
            resetPosition = this.transform.position;  //Local'leri world position'a çevirdim
        }
        else if (left_move.isLeftMove == true)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + left_move.leftMovement, this.gameObject.transform.position.y); //Local'leri world position'a çevirdim
            resetPosition = this.transform.position;  //Local'leri world position'a çevirdim
        }

        if (this.finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
                mousePos_local = this.gameObject.transform.localPosition;
            }
        }


        

        mouseUp_And_down();

        if (this.isInTarget == true)  //
        {
            StartCoroutine(this.drop_particle_effect()); //
        }  // 

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
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos;
        //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        //    startPosX = mousePos.x - this.transform.localPosition.x;
        //    startPosY = mousePos.y - this.transform.localPosition.y;
        //
        //    moving = true;
        //}
    }

    private void OnMouseUp()
    {

        this.mouseUp = true;
        this.mouseDown = false;

        // moving = false;
        //
        // if( Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) <= 0.5f && 
        //     Mathf.Abs(this.transform.localPosition.y - target.transform.localPosition.y) <=  0.5f)
        // {
        //     this.transform.position = target.transform.localPosition;
        //     finish = true;
        // }
        //
        // else
        // {
        //     this.transform.position = resetPosition;
        // }
    }


    private void OnMouseEnter()
    {
        this.isOnMouseEnter = true;
    }

    private void OnMouseExit()
    {
        this.isOnMouseEnter = false;
    }

    private IEnumerator drop_particle_effect()  // 
    {
        
        yield return new WaitForSeconds(1.5f); // 

        this.isInTarget = false; //


        // if (this.drop_particle.activeSelf && this.isOnMouseEnter == true && this.mouseDown == true && this.mouseUp == false)
        // {
        //     //this.drop_particle.SetActive(false);
        //     //this.isInTarget = false;
        //     Debug.Log("IEnumerator çalýþdý xx");
        //     this.drop_particle.SetActive(false);
        // }


    }
    void mouseUp_And_down()
    {
        

        this.gameObject.GetComponent<pickup_new>().enabled = false;  //Burada pickup scriptini etkisiz hale getirdim bug olmamasý için

        
        
        
        



        if (this.isOnMouseEnter == true && this.mouseDown == true && this.mouseUp == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.transform.localScale = new Vector3((float)pickup_new.object_dimension.x, (float)pickup_new.object_dimension.y, pickup_new.object_dimension.z);

                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                this.moving = true;
            }

            if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 0.5f &&  // Local'leri world position'a çevirdim
                Mathf.Abs(this.transform.position.y - target.transform.position.y) <= 0.5f) // Local'leri world position'a çevirdim
            {
                if (this.isFirsTime == true)
                {
                    Instantiate(this.drop_particle, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                    this.isFirsTime = false;
                    
                    deneme = false;

                }
                this.drop_particle.SetActive(true);

                
                this.isInTarget = true;



            }

            else if (Mathf.Abs(this.transform.position.x - target.transform.position.x) > 0.5f &&  // Local'leri world position'a çevirdim
                    Mathf.Abs(this.transform.position.y - target.transform.position.y) > 0.5f) // Local'leri world position'a çevirdim
            {
                if (this.isInTarget = false && drop_particle.activeSelf && this.gameObject.GetComponent<Collider2D>().IsTouching(target.GetComponent<Collider2D>()) == false) 
                { 
                    drop_particle.SetActive(false);
                    //Invoke("deneme_", 1);
                    //deneme = true;
                }
            }
        }

        if (this.mouseUp == true && this.mouseDown == false)
        {
            this.moving = false;

            

                if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 0.5f &&  // Local'leri world position'a çevirdim
                Mathf.Abs(this.transform.position.y - target.transform.position.y) <= 0.5f) // Local'leri world position'a çevirdim
            {


                this.transform.position = target.transform.position; //Local'leri world position'a çevirdim

                                


                place_correct = true;
                //transform.parent = null;



                if (firstTimeSound == true)
                {
                    audioSource_.Play(); //
                    firstTimeSound = false;
                }

                this.finish = true;

                if (this.isOnMouseEnter == true && this.finish == true)  // slot'lar boþaldý mý? komutu
                {
                    Debug.Log(this.Slot_index_);
                    inventory_.isFull[this.Slot_index_] = false;
                }

                if (this.gameObject.transform.childCount == 3)   // Game objenin içindeki ipucu iþaretlerini silme ve particle effecti setactive(false) yapma
                {
                    Debug.Log("child var");
                    Destroy(this.gameObject.transform.GetChild(0).gameObject);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false); // 

                }

                if (this.target.transform.childCount == 1) // target obejenin içindeki ipucu iþaretlerini silme
                {


                    Destroy(this.target.transform.GetChild(0).gameObject);
                }
            }

            else
            {
                this.transform.position = resetPosition;
                this.gameObject.transform.localScale = new Vector3((float)pickup_new.object_dimension.x / 2f, (float)pickup_new.object_dimension.y / 2f, pickup_new.object_dimension.z);

                //if ((Mathf.Abs(this.transform.localPosition.x - target.transform.localPosition.x) >= 0.5f &&
                //Mathf.Abs(this.transform.localPosition.y - target.transform.localPosition.y) >= 0.5f)) 
                //{ inventory_.isFull[pickup_new.slot_Index] = true; }

                place_correct = false;

                this.finish = false;
                                
            }
        }
    }


    void deneme_()
    {
        deneme = false;
    }

    void inventory_empty()
    {
       //for (int i = 0; i < inventory_.slots.Length; i++)
       //{
       //    if (inventory_.isFull[i] == true &&  (pickup_new.slot_Index==i))
       //    {
       //
       //        inventory_.isFull[i] = false;               
       //
       //
       //           
       //        break;
       //    }
       //}


       //if(finish ==true)
       //{
       //    inventory_.isFull[slot_index__] = false;
       //}
    }

   //private void OnTriggerEnter2D(Collider2D other)
   //{
   //     //slot_index__=other.GetComponent<slot_number>().Slot_Number_;
   //     Debug.Log("nesneler deðiyor  xxx");
   //
   //     if (other.gameObject.CompareTag("slot1"))
   //     {
   //         Debug.Log("nesneler deðiyor  xxx");
   //         if(finish == true)
   //         {
   //             inventory_.isFull[0] = false;
   //         }
   //     }
   // }

   
}
