using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject player;// Reference to the player object to activate, if needed
    public bool gateActive = false;
    public Rigidbody2D boxColliderOther;
    public Rigidbody2D boxColliderMy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //OnTriggerEnter2D checks if the colldied object has the tag "Gate"
        //If true, disables the 'BoxCollider2D' for both the collided object and current object 
        
        if ( collision.CompareTag("TriggerGateEmpty"))
        {
            //Find a way to get the boxcollider in the gate
            gateActive = true;
            Debug.Log("Found Gate and disabling colliders");
            foreach ( BoxCollider2D bc in collision.GetComponentsInChildren<BoxCollider2D>())
            {
                if (bc.CompareTag("Gate"))
                {
                    //bc.gameObject.SetActive(false);
                    bc.enabled = false;
                }
            }

            foreach (BoxCollider2D bc in this.GetComponentsInChildren<BoxCollider2D>())
            {
                if (bc.CompareTag("Gate"))
                {
                    //bc.gameObject.SetActive(false);
                    bc.enabled = false;
                }
            }
            //this.GetComponentsInChildren<BoxCollider2D>().isTrigger = false;

            //GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    private void Update()
    {
        //Debug.Log(gateActive);
        //Finds all game objects with the tag "Gate" using 'GameObject.FindGameObjectsWithTag("Gate").
        //Iterates though each gate object and enables its 'BoxCollider2D'
        //Enables the 'BoxCollider2D' of the current game object
        // Enable colliders for all objects tagged as "Gate"
       //// GameObject[] gates = GameObject.FindGameObjectsWithTag("Gate");
       // foreach (GameObject gate in gates)
       // {
            
       //     if (gateActive == true)
       //     {
       //         gate.GetComponent<BoxCollider2D>().enabled = true;
       //     }
            
       // }

        // Enable the collider of the current gameObject
        //GetComponent<BoxCollider2D>().enabled = true;

        /*if (gateActive)
           {
            boxColliderMy.isTrigger = false;
            boxColliderOther.isTrigger = false;
        }
        else
        {
            boxColliderMy.isTrigger = true;
            boxColliderOther.isTrigger = true;
        }*/
    }


   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerGateEmpty") )
        {            
            Debug.Log("Exiting and enabling colliders");
            gateActive = false;

            foreach (BoxCollider2D bc in collision.GetComponentsInChildren<BoxCollider2D>())
            {
                if (bc.CompareTag("Gate"))
                {
                    //bc.gameObject.SetActive(true);
                    bc.enabled = true;
                }
                    
                
            }

            foreach (BoxCollider2D bc in this.GetComponentsInChildren<BoxCollider2D>())
            {

                if (bc.CompareTag("Gate"))
                {
                    //bc.gameObject.SetActive(true);
                    bc.enabled = true;
                }

            }
            //boxColliderMy.enabled = true;
            //boxColliderOther.enabled = true;

            //collision.GetComponent<BoxCollider2D>().enabled = true;
            //GetComponent<BoxCollider2D>().enabled = true;
        }

       

        
    }

    
}


