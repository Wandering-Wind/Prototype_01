using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float stopTime = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is not null and tagged as "Player"
        if (other != null && other.CompareTag("Player"))
        {
            Debug.Log("Player collided with trigger object!");
            Movement movement = other.GetComponent<Movement>();
            if (movement != null)
            {
                movement.StopMovement(stopTime);
            }
        }
    }
}

