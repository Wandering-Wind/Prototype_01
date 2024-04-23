using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private Collider2D myCollider;
    [SerializeField]
    Movement Movement;
    void Start()
    {
        
        Movement.enabled = false;
        // Get the collider component of this gate
        myCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //This  function is called when a trigger collider enters the gate's trigger collider.
        // Check if the other collider is also a gate
        if (other.CompareTag("Gate"))
        {
            // Disable the collider of both gates
            myCollider.enabled = false;
            other.GetComponent<Collider2D>().enabled = false;
            Movement.enabled = true;
            Debug.Log("Gate works");
        }
    }
}
