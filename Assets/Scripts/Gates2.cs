using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates2 : MonoBehaviour
{
    private Collider2D myCollider;
    [SerializeField]
    private Movement movementScript;

    void Start()
    {
        if (movementScript == null)
        {
            Debug.LogError("Movement script not assigned to Gates script.");
            return;
        }
        

        movementScript.enabled = false;

        // Get the collider component of this gate
        myCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // This function is called when a trigger collider enters the gate's trigger collider.
        // Check if the other collider is also a gate
        if (other.CompareTag("Gate"))
        {
            // Disable the collider of both gates
            myCollider.enabled = false;
            Collider2D otherCollider = other.GetComponent<Collider2D>();
            if (otherCollider != null)
            {
                otherCollider.enabled = false;
            }
            else
            {
                Debug.Log("Collider2D component not found on the other gate.");
                return;
            }

            movementScript.enabled = true;
            Debug.Log("Gate works");
        }
    }
}
