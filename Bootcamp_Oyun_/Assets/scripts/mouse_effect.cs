using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_effect : MonoBehaviour
{
    public Texture2D defaultTexture; // mouse'un default resmi
    public Texture2D touchableTexture; // mouse etkile�ime ge�ilebilen bir nesnenin �zerindeyse mouse imlecinin yeni i�areti


   void Start()
   {
      //default texture'�n atanmas�
        Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width/4, defaultTexture.height/4), CursorMode.Auto); 
   }
   
   private void OnMouseEnter()
   {
        // mouse etkile�ime ge�ilebilen bir nesnenin �zerindeyse yeni mouse imlecinin atanmas�: 
       if(gameObject.CompareTag("touchable"))
       {
           Cursor.SetCursor(touchableTexture, new Vector2(touchableTexture.width / 4, touchableTexture.height / 4), CursorMode.Auto);
       }
   }
   
    // mouse etkile�ime ge�ilebilen bir nesnenin �zerinden ��kt��� zaman mouse imlecinin eski haline d�nemsi:
   private void OnMouseExit()
   {
       Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width /4, defaultTexture.height /4), CursorMode.Auto);
   }

}
