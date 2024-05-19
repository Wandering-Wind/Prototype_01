using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{ 
public GameObject player; // Reference to the child object to activate
    public GameObject otherTile;
    public GameObject ourTile;
    
  

    private void OnTriggerStay2D(Collider2D collision)
    {
        otherTile = collision.gameObject;//OtherGameObject
        //GameObject othergate = otherTile.transform.GetChild(0).gameObject;
       // GameObject othergate = GameObject.Find("Gate");
        ourTile = gameObject;
        //Debug.Log($"Collision detected between {gameObject.name} and {collision.gameObject.name}"); // Log the names of the colliding objects
        //Debug.Log($"Collision detected between {this.gameObject.name} and {otherTile.name}");
       

        if (collision.CompareTag("Gate"))
        {
            Debug.Log("Found Gate and enabling player");
            otherTile.GetComponent<BoxCollider2D>().enabled = false;
            ourTile.GetComponent<BoxCollider2D>().enabled = false;
            
            
        }

        //otherTile.GetComponent<Gates>().GetComponentInChildren<BoxCollider2D>.enabled = false;
        //ourTile.GetComponent<Gates>().enabled = false;
        // Check if the collided object has a specific tag (optional)
        // If you want to activate only when colliding with certain objects, uncomment and set the tag
        // if (collision.gameObject.CompareTag("YourTag"))
        {
            
            // Activate the specific child object
            if (player != null)
            {
                Debug.Log($"Activating object: {player.name}"); // Log the activation action
                player.SetActive(true);

            }
            else
            {
                Debug.LogWarning("player is not assigned!"); // Warn if the object to activate is not set
                player.SetActive(false);
            }
            
            
        }
    }

    

    private void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("player is not assigned in the Inspector!"); // Initial check for the reference
            player.SetActive(false);
        }


    }

    private void Update()
    {
       otherTile.GetComponent<BoxCollider2D>().enabled = true;
        ourTile.GetComponent<BoxCollider2D>().enabled = true;
        
    }
}
