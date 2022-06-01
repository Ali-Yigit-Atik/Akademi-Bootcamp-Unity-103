using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_effect : MonoBehaviour
{
    public Texture2D defaultTexture; // mouse'un default resmi
    public Texture2D touchableTexture; // mouse etkileþime geçilebilen bir nesnenin üzerindeyse mouse imlecinin yeni iþareti


   void Start()
   {
      //default texture'ýn atanmasý
        Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width/4, defaultTexture.height/4), CursorMode.Auto); 
   }
   
   private void OnMouseEnter()
   {
        // mouse etkileþime geçilebilen bir nesnenin üzerindeyse yeni mouse imlecinin atanmasý: 
       if(gameObject.CompareTag("touchable"))
       {
           Cursor.SetCursor(touchableTexture, new Vector2(touchableTexture.width / 4, touchableTexture.height / 4), CursorMode.Auto);
       }
   }
   
    // mouse etkileþime geçilebilen bir nesnenin üzerinden çýktýðý zaman mouse imlecinin eski haline dönemsi:
   private void OnMouseExit()
   {
       Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width /4, defaultTexture.height /4), CursorMode.Auto);
   }

}
