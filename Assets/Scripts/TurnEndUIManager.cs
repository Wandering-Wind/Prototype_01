using UnityEngine;
using UnityEngine.UI;

public class TurnEndUIManager : MonoBehaviour
{
    public GameObject turnEndPanel; // The UI panel that pops up
    public Button endTurnButton; // The button on the panel

    private TurnManager turnManager;
    public static bool isPanelActive; // Flag to indicate if the panel is active

    void Start()
    {
        turnEndPanel.SetActive(false); // Make sure the panel is initially inactive
        turnManager = FindObjectOfType<TurnManager>();
        if (turnManager == null)
        {
            Debug.LogError("TurnManager not found in the scene.");
        }

        endTurnButton.onClick.AddListener(OnEndTurnButtonClicked);
        isPanelActive = false; // Initialize the flag
    }

    void OnEndTurnButtonClicked()
    {
        turnEndPanel.SetActive(false); // Hide the panel when the button is clicked
        isPanelActive = false; // Update the flag
        turnManager.SwitchTurn(); // Switch turn in the TurnManager
    }

    public void ShowTurnEndPanel()
    {
        turnEndPanel.SetActive(true); // Show the panel
        isPanelActive = true; // Update the flag
    }
}
