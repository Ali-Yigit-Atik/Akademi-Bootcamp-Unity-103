using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_effect : MonoBehaviour
{
    public Texture2D defaultTexture; // mouse'un default resmi
    public Texture2D touchableTexture; // mouse etkileþime geçilebilen bir nesnenin üzerindeyse mouse imlecinin yeni iþareti

    private bool isMouseEnter = false; 
    private bool isDefault = false;

   void Awake()
   {
      //default texture'ýn atanmasý
        Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width/4, defaultTexture.height/4), CursorMode.Auto); 
   }

    private void Update()
    {
        if (isMouseEnter == true && isDefault == true)
        {
            if (gameObject.CompareTag("touchable"))
            {
                Cursor.SetCursor(touchableTexture, new Vector2(touchableTexture.width / 4, touchableTexture.height / 4), CursorMode.Auto);

                isDefault = false;


            }

        }

        if(isMouseEnter == false && isDefault == false)
        {
            Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width / 4, defaultTexture.height / 4), CursorMode.Auto);
            isDefault = true;
        }
    }

    private void OnMouseEnter()
   {
        // mouse etkileþime geçilebilen bir nesnenin üzerindeyse yeni mouse imlecinin atanmasý: 
        //if(gameObject.CompareTag("touchable"))
        //{
        //    Cursor.SetCursor(touchableTexture, new Vector2(touchableTexture.width / 4, touchableTexture.height / 4), CursorMode.Auto);
        //}
        isMouseEnter = true;
   }
   
    // mouse etkileþime geçilebilen bir nesnenin üzerinden çýktýðý zaman mouse imlecinin eski haline dönemsi:
   private void OnMouseExit()
   {
        //Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width /4, defaultTexture.height /4), CursorMode.Auto);
        isMouseEnter = false;
   }

}
