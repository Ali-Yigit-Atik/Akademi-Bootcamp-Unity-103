using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_effect : MonoBehaviour
{
    public Texture2D defaultTexture;
    public Texture2D touchableTexture;


   void Start()
   {
       Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width/4, defaultTexture.height/4), CursorMode.Auto);
   }
   
   private void OnMouseEnter()
   {
       if(gameObject.CompareTag("touchable"))
       {
           Cursor.SetCursor(touchableTexture, new Vector2(touchableTexture.width / 4, touchableTexture.height / 4), CursorMode.Auto);
       }
   }
   
   private void OnMouseExit()
   {
       Cursor.SetCursor(defaultTexture, new Vector2(defaultTexture.width /4, defaultTexture.height /4), CursorMode.Auto);
   }

}
