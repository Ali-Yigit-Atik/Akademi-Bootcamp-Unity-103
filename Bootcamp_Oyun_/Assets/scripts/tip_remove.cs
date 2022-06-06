using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip_remove : MonoBehaviour
{

    //  Mankenin elinde papirüs bulunan game objesi açýldýðýnda oyuncuya yön göstericek olan tip iþareti de açýlýyor.
    // Papirüs ve papirüs ile baðýntýlý olan aðaç puzzle'ý çözüldüðünde papirüsün tip iþareti kaldýrýlsýn. Bu þekilde ilgli olan puzzle'ý çözdüðü de belli olsun.

    public GameObject papirus;

    private void Update()
    {
        if (papirus.transform.childCount>0)
        {
            Destroy(papirus.transform.GetChild(0).gameObject);
        }
    }
}
