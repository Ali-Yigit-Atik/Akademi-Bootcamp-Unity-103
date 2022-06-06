using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_true : MonoBehaviour
{
    
    // Havuz puzzle'ý çözüldüðünde havuzdan asansör düðmesini çýkarma kodlarý
    
    public GameObject puzzleObject; // havuzdan düðmeyi alacak olan nesne (havuz puzzle'ýnýn çözülmesi için gerekli olan nesne)
    private set_active setActive; // asansör düðmesini aktif etmek için kullanýlacak olan script
    private Vector3 targetCenter;  // puzzleObject'in yerleþmesi gerek koordinat

    private void Start()
    {
        setActive = this.gameObject.GetComponent<set_active>();
        setActive.enabled = false;
        setActive.openedObject.SetActive(false); // setActive scriptinin içindeki obje bug olup oyunun baþýnda açýlmamasý için tedbir
        targetCenter = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().bounds.center;
    }

    private void Update()
    {
        if(targetCenter == puzzleObject.transform.position) // puzzleObject doðru yere yerleþti havuzun içinden saklanan nesneyi aktive edecek kod 
        {
            setActive.enabled = true; //havuzun içinden saklanan nesneyi aktive edecek kod 
        }
    }
}
