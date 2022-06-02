using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_active : MonoBehaviour
{
    public GameObject openedObject;
    public GameObject opendenParticle;

    private void Update()
    {
        if(openedObject.activeSelf == false)
        {
            openedObject.SetActive(true);
            Instantiate(opendenParticle, openedObject.transform.position, Quaternion.identity, openedObject.transform);
        }
    }
}
