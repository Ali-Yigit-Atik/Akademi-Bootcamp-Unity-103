using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papirus_open : MonoBehaviour
{

    private bool onenter = false;
    [SerializeField] GameObject papirusCanvas;

    private void Start()
    {
        papirusCanvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(onenter==true && Input.GetMouseButtonDown(0))
        {
            papirusCanvas.gameObject.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        
        onenter = true; // mouse nesnenin i�aretinin �zerinde
    }

    private void OnMouseExit()
    {
        
        onenter = false;  // mouse nesnenin �zerinde de�il
    }

    public void papirus_canvas_pasif()
    {
        papirusCanvas.gameObject.SetActive(false);
    }
}
