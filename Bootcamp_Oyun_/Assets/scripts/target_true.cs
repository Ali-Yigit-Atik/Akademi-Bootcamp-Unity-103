using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_true : MonoBehaviour
{
    public GameObject puzzleObject;
    private set_active setActive;
    private Vector3 targetCenter;

    private void Start()
    {
        setActive = this.gameObject.GetComponent<set_active>();
        setActive.enabled = false;
        setActive.openedObject.SetActive(false);
        targetCenter = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().bounds.center;
    }

    private void Update()
    {
        if(targetCenter == puzzleObject.transform.position)
        {
            setActive.enabled = true;
        }
    }
}
