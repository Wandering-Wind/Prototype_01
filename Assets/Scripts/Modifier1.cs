using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Modifier1 : MonoBehaviour
{
    public int extraMoves = 3;  // The number of extra moves granted by this modifier
    private TurnManager turnManager;
    private Collider2D myCollider; // Reference to the collider

    public Text modifierMessageText;  // Reference to the UI Text element

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
            Destroy(gameObject);
        }
    }

    private void DisplayMessage(string message)
    {
        if (modifierMessageText != null)
        {
            modifierMessageText.text = message;
            // Optionally, you can add code to hide the message after a few seconds.
            StartCoroutine(HideMessageAfterDelay(2f));
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (modifierMessageText != null)
        {
            modifierMessageText.text = "";  // Clear the message
        }
    }
}
