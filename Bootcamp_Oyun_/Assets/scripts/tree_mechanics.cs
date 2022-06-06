using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics : MonoBehaviour
{
    public GameObject[] trees; // aðaç objeleri konulacak bu array'e
    public bool[] isTargetPlacesTrue; // aðaç objelerinin doðru yere konulduðunu teyit etmesi için position'larý kullanýlacak olan nesneler
    
    private tip_remove tipRemove; // Bu puzzle çözüldüðünde bu puzzle'ýn çözülmesi hakkýnda ipucu veren papirüsün tip iþareti kaldýrýlsýn

    public static bool isHeartTreeBroke = false; // Bu puzzle çözüldüðünde kalp þeklinde ki aðaç kýrýlacak ve arkasýndaki asansöör düðmesi ortaya çýkacak.
                                                 //  Bu puzzle'ýn çözülüp heart tree'nin kýrýlýp kýrýlmayacaðýný baþka bir scripte bildiren static boolean deðeri

    private void Awake()
    {
        

        tipRemove = this.gameObject.GetComponent<tip_remove>();
        tipRemove.enabled = false;

        for (int i = 0; i <= trees.Length - 1; i++) // Papirüs açýlana kadar bu aðaçlarla etkileþime geçilememesi için collider'larý kapatma
        {
            trees[i].GetComponent<Collider2D>().enabled = false;
            isTargetPlacesTrue[i] = false;
        }
        isHeartTreeBroke = false;

    }

    private void Update()
    {
        if (isTargetPlacesTrue[0] == true && isTargetPlacesTrue[1] == true && isTargetPlacesTrue[2] == true) // tüm aðaçlarýn yerleri doðrumu
        {
            for(int i =0; i<=isTargetPlacesTrue.Length-1; i++)
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<tree_mechanics2>().enabled = false; // aðaçlarý hareket kodlarýnýn buludnuðu scripti kapatma
                Destroy(this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject); // her aðacýn tip iþaretini kaldýrma

                
                this.gameObject.transform.GetChild(i).gameObject.tag = "Untagged"; // mouse imleci aðaçlarýn üzerine geldiðinde deðiþmemesi için aðaçlarýn tag'ýný deðiþtiren kodlar
            }

            
            tipRemove.enabled = true; // papirüsün tip iþaretini kaldýran scripti aktvive etme
            isHeartTreeBroke = true; ; // heart tree nin kýrýlmasý için boolean koþulunu deðiþtirme
        }
    }
}
