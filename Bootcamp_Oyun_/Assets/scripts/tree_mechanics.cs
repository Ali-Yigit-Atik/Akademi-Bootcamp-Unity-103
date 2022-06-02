using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics : MonoBehaviour
{
    public GameObject[] trees; // aðaç objeleri konulacak bu array'e
    public bool[] isTargetPlacesTrue;
    private set_active setActive;
    private tip_remove tipRemove;

    private void Awake()
    {
        setActive = this.gameObject.GetComponent<set_active>();
        setActive.enabled = false;
        setActive.openedObject.SetActive(false);

        tipRemove = this.gameObject.GetComponent<tip_remove>();
        tipRemove.enabled = false;

    }

    private void Update()
    {
        if (isTargetPlacesTrue[0] == true && isTargetPlacesTrue[1] == true && isTargetPlacesTrue[2] == true)
        {
            for(int i =0; i<=isTargetPlacesTrue.Length-1; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<tree_mechanics2>().enabled = false;
                Destroy(this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject);

                //this.gameObject.transform.GetChild(i).gameObject.GetComponent<mouse_effect>().enabled = false;
                this.gameObject.transform.GetChild(i).gameObject.tag = "Untagged";
            }

            setActive.enabled = true;
            tipRemove.enabled = true;
        }
    }
}
