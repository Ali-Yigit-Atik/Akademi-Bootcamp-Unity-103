using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_mechanics2 : MonoBehaviour
{
    public GameObject treesParentObject;
    public GameObject targetPlace;

    private tree_mechanics trees_mech;
    private bool onenter = false;

    private int a;
    private Vector3 startPosition;
    private GameObject nextTree;


    private AudioSource audioSource_;

    public AudioClip movingSound; // 

    private void Start()
    {
        trees_mech = treesParentObject.GetComponent<tree_mechanics>();
        audioSource_ = this.gameObject.GetComponent<AudioSource>();  // belleðe yazma
        audioSource_.clip = movingSound; // 
    }

    private void Update()
    {
        //startPosition = this.gameObject.transform.position;

        for (int i = 0; i <= trees_mech.trees.Length - 1; i++)
        {
            if (this.gameObject.transform.position == trees_mech.trees[i].transform.position)
            {
                a = i;
            }
        }

        if (onenter == true && Input.GetMouseButtonDown(0))
        {
            move();
            audioSource_.Play();
        }

        if (Mathf.Abs(this.transform.position.x - targetPlace.transform.position.x) <= 0.5f &&
                Mathf.Abs(this.transform.position.y - targetPlace.transform.position.y) <= 0.5f)
        {

            trees_mech.isTargetPlacesTrue[a] = true;
            Debug.Log("trees_mech.isTargetPlacesTrue[a] = true");
        }
        else 
        {
            trees_mech.isTargetPlacesTrue[a] = false;
        }

    }

    public void move()
    {
        startPosition = this.gameObject.transform.position;
        

        if (a != trees_mech.trees.Length - 1)
        {
            nextTree = trees_mech.trees[a + 1];

            trees_mech.trees[a] = null;
            this.gameObject.transform.position = trees_mech.trees[a + 1].transform.position;
            trees_mech.trees[a+1].transform.position = startPosition;

            trees_mech.trees[a + 1] =  this.gameObject;
            trees_mech.trees[a] = nextTree;
        }

        if(a == trees_mech.trees.Length - 1)
        {
            nextTree = trees_mech.trees[a - 1];

            this.gameObject.transform.position = trees_mech.trees[a -1].transform.position;
            trees_mech.trees[a-1].transform.position = startPosition;

            trees_mech.trees[a - 1] = this.gameObject;
            trees_mech.trees[a] = nextTree;
        }

        
    }

    private void OnMouseEnter()
    {

        onenter = true; // mouse nesnenin iþaretinin üzerinde
    }

    private void OnMouseExit()
    {

        onenter = false;  // mouse nesnenin üzerinde deðil
    }
}
