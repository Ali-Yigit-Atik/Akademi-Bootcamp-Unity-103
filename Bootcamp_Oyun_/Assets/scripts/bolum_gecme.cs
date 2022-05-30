using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolum_gecme : MonoBehaviour
{
    private bool onenter = false;

    public string bolum_ismi="";


    private void Update()
    {

        if (onenter == true && Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(bolum_ismi);
        }

        
    }

  

    private void OnMouseEnter()
    {
        
        onenter = true;
    }

    private void OnMouseExit()
    {
        
        onenter = false;
    }
}
