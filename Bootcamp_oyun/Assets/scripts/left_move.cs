using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_move : MonoBehaviour
{
    
    public bool onenter=false;
    public int speed = 5;
    public SpriteRenderer sr;
    public Color redish;

    public static bool isLeftMove = false;//
    public static float leftMovement;//

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        

        if (onenter==true && Input.GetMouseButton(0))
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
