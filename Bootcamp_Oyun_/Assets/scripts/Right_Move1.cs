using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Move1 : MonoBehaviour
{
    public static bool onenter = false;
    public int speed = 5;
    public SpriteRenderer sr;

    public static bool isRightMove = false;//
    public static float rigthMovement;//

    public Color redish;

    public GameObject rightWall; // kameranýn saða gitmesini engelleyecek olan engel

    public static float rightArrowPosition;
    public static float rightWallPosition;

    private float widht;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        widht = rightWall.GetComponent<Collider2D>().bounds.size.x;
    }

    private void Update()
    {
        rightArrowPosition=this.gameObject.transform.position.x;
        rightWallPosition = rightWall.transform.position.x - widht/2;

        if (onenter == true && Input.GetMouseButton(0) && this.gameObject.transform.position.x < rightWall.transform.position.x - widht / 2)
        {
            rigthMovement = (1 * speed * Time.deltaTime);//
            gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x + rigthMovement, gameObject.transform.parent.transform.position.y);
            sr.color = redish;
            isRightMove = true;//
        }

        if (Input.GetMouseButtonUp(0))
        {
            sr.color = Color.white;
            isRightMove = false;//
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
