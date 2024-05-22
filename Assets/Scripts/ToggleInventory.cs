using UnityEngine;
using UnityEngine.UI;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Button toggleButton;
    private bool isInventoryVisible = true;

    void Start()
    {
        // Add listener for button click
        toggleButton.onClick.AddListener(ToggleInventoryVisibility);
        Debug.Log("Start method called and listener added.");
    }

    void ToggleInventoryVisibility()
    {
        // Toggle visibility
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);

        // Update button text
        toggleButton.GetComponentInChildren<Text>().text = isInventoryVisible ? "Hide Inventory" : "Show Inventory";
        Debug.Log("Button clicked. Inventory visibility: " + isInventoryVisible);
    }
}
