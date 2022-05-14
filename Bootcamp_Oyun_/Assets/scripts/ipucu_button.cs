using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipucu_button : MonoBehaviour
{
    
    public GameObject[] tips_image;
    
    private bool onenter = false;
    
    private void Update()
    {
        if (onenter && Input.GetMouseButton(0))
        {
            for(int i =0; i<=tips_image.Length-1; i++)
            {
                
                if(tips_image[i] != null)
                {
                    tips_image[i].SetActive(true);
                }
            }
        }
        else if (onenter && Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i <= tips_image.Length - 1; i++)
            {
                
                if (tips_image[i] != null)
                {
                    tips_image[i].SetActive(false);
                }
            }
        }
    }
    
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(3.5f, 3.5f, 1);
        onenter = true;
    }
    
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(2.5f, 2.5f, 1);
        onenter = false;
    }
}
