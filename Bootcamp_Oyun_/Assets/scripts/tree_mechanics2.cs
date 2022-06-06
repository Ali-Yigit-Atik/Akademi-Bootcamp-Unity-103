using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics2 : MonoBehaviour
{
    public GameObject treesParentObject; // aðaçlarýn parent objesi
    public GameObject targetPlace; // aðacýn varmasý gerekn doðru konuml

    private tree_mechanics trees_mech;
    private bool onenter = false; // mouse aðacýn üzerinde mi deðil mi kontrol boolean'ý

    private int a; // aðaçlarýn ebevyn obesi içinde array tanýmlý ve bu aðaçlarda o arrayin içinde tanýmlý. Bu hareket kodunda array içinde de hareket edicekler.
                   // array içinde hareket etmesine yardýmcý olacak bir variable tanýmlanýr
    private Vector3 startPosition; // aðacýn baþlangýç pozisyonu
    private GameObject nextTree; // aðacýn array içinde hareket ederken yer deðiþtireceði diðer aðaç


    private AudioSource audioSource_;

    public AudioClip movingSound; // 

    private void Start()
    {
        trees_mech = treesParentObject.GetComponent<tree_mechanics>(); // scriptin variable olarak atanmasý
        audioSource_ = this.gameObject.GetComponent<AudioSource>();  
        audioSource_.clip = movingSound; //  ses klibi atandý
    }

    private void Update()
    {
        //startPosition = this.gameObject.transform.position;

        for (int i = 0; i <= trees_mech.trees.Length - 1; i++) // bu aðaç objesi array'in kaçýncý elemaný
        {
            if (this.gameObject.transform.position == trees_mech.trees[i].transform.position)
            {
                a = i;
            }
        }

        if (onenter == true && Input.GetMouseButtonDown(0)) // aðacýn üzerine týkladýðýnda yer deðiþtir
        {
            move();
            audioSource_.Play();
        }

        if (Mathf.Abs(this.transform.position.x - targetPlace.transform.position.x) <= 0.5f &&
                Mathf.Abs(this.transform.position.y - targetPlace.transform.position.y) <= 0.5f) // aðaç doðru konumda ise doðru konumda olduðunu boolean olatak bildir
        {

            trees_mech.isTargetPlacesTrue[a] = true;
            Debug.Log("trees_mech.isTargetPlacesTrue[a] = true");
        }
        else 
        {
            trees_mech.isTargetPlacesTrue[a] = false; // // aðaç doðru konumda ise doðru konumda deðilse boolean olatak bildir
        }

    }

    public void move() // aðaçlarýn hareket kodlarý
    {
        startPosition = this.gameObject.transform.position; // aðacýn üzerine týklandýðý andaki pozisyonu atanýr
        

        if (a != trees_mech.trees.Length - 1) // Bu aðaç arrayin son elemaný deðilse saða hareket etsin
        {
            nextTree = trees_mech.trees[a + 1]; // bu aðaç ile yer deðiþtirecek olan aðaç atanýr

            trees_mech.trees[a] = null;
            this.gameObject.transform.position = trees_mech.trees[a + 1].transform.position; // pozisyon atanýr
            trees_mech.trees[a+1].transform.position = startPosition; // yer deðiþtirilecek olan aðacýn pozisyonu bu aðacýn eski pozisyonuna atanýr

            trees_mech.trees[a + 1] =  this.gameObject;  // bu aðaç, saðýndaki aðacýn array deki yerine geçer
            trees_mech.trees[a] = nextTree;  // bu aðaç ile saðýndaki aðaç , bu aðacýn array deki yerine geçer
        }

        if(a == trees_mech.trees.Length - 1) // Bu aðaç arrayin son elemaný ise sola hareket etsin
        {
            nextTree = trees_mech.trees[a - 1]; // bu aðaç ile yer deðiþtirecek olan aðaç atanýr

            this.gameObject.transform.position = trees_mech.trees[a -1].transform.position; // pozisyon atanýr
            trees_mech.trees[a-1].transform.position = startPosition; // yer deðiþtirilecek olan aðacýn pozisyonu bu aðacýn eski pozisyonuna atanýr

            trees_mech.trees[a - 1] = this.gameObject; // bu aðaç, solundaki aðacýn array deki yerine geçer
            trees_mech.trees[a] = nextTree;  // bu aðacýn solundaki aðaç, bu aðacýn array deki yerine geçer
        }

        
    }

    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin  üzerinde
    }

    private void OnMouseExit()
    {

        onenter = false;  // mouse nesnenin üzerinde deðil
    }
}
