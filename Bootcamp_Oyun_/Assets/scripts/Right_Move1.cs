using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Move1 : MonoBehaviour
{
    public static bool onenter = false; //mouse nesnenin üzerinde mi
    public int speed = 12; // hýz

    public SpriteRenderer sr;
    public Color redish; //ok tuþuna basýldýðýnda ok tuþunun alacaðý renk

    public static bool isRightMove = false; // hareket ediyor mu
    public static float rigthMovement; //// hareket miktari


    public GameObject rightWall; // kameranýn saða gitmesini engelleyecek olan engel

    public static float rightArrowPosition; // okun pozisyonu
    public static float rightWallPosition; // duvarýn pozisyonu

    public float normalSize = 3f;
    public float onPressSize = 4.5f;

    private float widht; // duvarýn(engelin) geniþliði

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // belleðe yazma
        widht = rightWall.GetComponent<Collider2D>().bounds.size.x; // duvarýn geniþliðini atama
    }

    private void Update()
    {
        rightArrowPosition=this.gameObject.transform.position.x; // okun pozisyonunu atama
        rightWallPosition = rightWall.transform.position.x - widht/2;  // duvarýn okla etkileþime geçtiði pozisyonu atama

        // oka basýldýðýnda sað tarafa hareket etsin

        if (onenter == true && Input.GetMouseButton(0) && this.gameObject.transform.position.x < rightWall.transform.position.x - widht / 2)
        {
            rigthMovement = (1 * speed * Time.deltaTime); // hareket miktarýný hesapla

            // karakterin ve kameranýn yeni pozisyonunu atama:
            gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x + rigthMovement, gameObject.transform.parent.transform.position.y);
            
            sr.color = redish; // oka basýlý tutulduðunda rengi deðiþsin
            isRightMove = true;// sað tarafa hareket ediyor
        }

        else //if(Input.GetMouseButtonUp(0)) // mouse tuþuna basýlma kesildiðinde
        {
            sr.color = Color.white; // okun rengi eski haline dönsün
            isRightMove = false;  // hareket etmiyor
        }
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(onPressSize, onPressSize, 1); // mouse ok üzerindeyken ok büyüsün
        onenter = true; // mouse ok iþaretinin üzerinde
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(normalSize, normalSize, 1); // mouse ok üzerinde deðilken eski boyutunda olsun
        onenter = false;  // mouse ok üzerinde deðil
    }
}
