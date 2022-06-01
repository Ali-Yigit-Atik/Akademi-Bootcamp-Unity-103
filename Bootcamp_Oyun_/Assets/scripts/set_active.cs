using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_active : MonoBehaviour
{
    public GameObject openedObject;

    private void Update()
    {
        if(openedObject.activeSelf == false)
        {
            openedObject.SetActive(true);
        }
    }
}
