using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_move : MonoBehaviour
{
    
    public static bool onenter=false;
    public int speed = 5;
    public SpriteRenderer sr;
    public Color redish;

    public static bool isLeftMove = false;//
    public static float leftMovement;//

    
    public GameObject leftWall;    // kameranýn sola gitmesini engelleyecek olan engel

    public static float leftArrowPosition;
    public static float leftWallPosition;

    private float widht;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        

        widht = leftWall.GetComponent<Collider2D>().bounds.size.x;
    }

    private void Update()
    {

        leftArrowPosition = this.gameObject.transform.position.x;
        leftWallPosition = leftWall.transform.position.x + widht/2;

        if (onenter==true && Input.GetMouseButton(0) && this.gameObject.transform.position.x > leftWall.transform.position.x + widht / 2)
        {
            leftMovement = (-1 * speed * Time.deltaTime);//
            gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x + leftMovement, gameObject.transform.parent.transform.position.y);
            
            sr.color = redish;
            isLeftMove = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            sr.color = Color.white;
            isLeftMove = false;
        }
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(3, 3, 1);
        onenter = true;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(2, 2, 1);
        onenter = false;
    }

    
}

