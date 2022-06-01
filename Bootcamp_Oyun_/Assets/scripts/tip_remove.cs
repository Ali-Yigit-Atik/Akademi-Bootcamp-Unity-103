using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip_remove : MonoBehaviour
{

    public GameObject papirus;

    private void Update()
    {
        if (papirus.transform.childCount>0)
        {
            Destroy(papirus.transform.GetChild(0).gameObject);
        }
    }
}
