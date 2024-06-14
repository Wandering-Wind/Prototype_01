using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Modifier1 : MonoBehaviour
{
    public int extraMoves = 3;  // The number of extra moves granted by this modifier
    private TurnManager turnManager;
    private Collider2D myCollider; // Reference to the collider

    public Text modifierMessageText;  // Reference to the UI Text element

    private Coroutine hideMessageCoroutine;  // Reference to the active coroutine

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        myCollider = GetComponent<Collider2D>(); // Get the collider component
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Playyer") && myCollider.enabled) // Check if collider is enabled
        {
            turnManager.AddExtraMove(extraMoves);
            DisplayMessage("Extra moves added!");
            myCollider.enabled = false; // Disable the collider to prevent further triggers

            // Move the object to an off-screen position
            MoveOffScreen();
        }
    }

    private void MoveOffScreen()
    {
        // Set the off-screen position, e.g., far outside the camera's view
        Vector3 offScreenPosition = new Vector3(-1000, -1000, 0);
        transform.position = offScreenPosition;
    }

    private void DisplayMessage(string message)
    {
        if (modifierMessageText != null)
        {
            modifierMessageText.text = message;
            Debug.Log("Message displayed: " + message);

            // Stop any existing coroutine before starting a new one
            if (hideMessageCoroutine != null)
            {
                StopCoroutine(hideMessageCoroutine);
                Debug.Log("Existing coroutine stopped.");
            }

            hideMessageCoroutine = StartCoroutine(HideMessageAfterDelay(2f));
        }
        else
        {
            Debug.LogError("modifierMessageText is null!");
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        Debug.Log("HideMessageAfterDelay coroutine started.");
        yield return new WaitForSeconds(delay);
        Debug.Log("Waited for " + delay + " seconds.");

        if (modifierMessageText != null)
        {
            modifierMessageText.text = "";  // Clear the message
            Debug.Log("Message hidden.");
        }
        else
        {
            Debug.LogError("modifierMessageText is null when hiding the message!");
        }

        // Reset coroutine reference after completion
        hideMessageCoroutine = null;

        // Optionally destroy the object after the message is hidden, if you need to remove it completely
        //Destroy(gameObject);
    }
}
