using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Move1 : MonoBehaviour
{
    public bool onenter = false;
    public int speed = 5;
    public SpriteRenderer sr;

    public static bool isRightMove = false;//
    public static float rigthMovement;//

    public Color redish;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        if (onenter == true && Input.GetMouseButton(0))
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
