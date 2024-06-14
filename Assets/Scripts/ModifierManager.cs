using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifierManager : MonoBehaviour
{
    public GameObject[] modifierPrefabs; // Array of modifier prefabs
    public List1 tileListScript; // Reference to List1.cs script
    public Transform offScreenTransform; // Location to hide unused modifiers

    public List<string> excludedTileNames; // List of tile names to exclude
    private List<GameObject> activeModifiers = new List<GameObject>();
    private HashSet<GameObject> occupiedTiles = new HashSet<GameObject>();

    public Text modifierMessageText;  // Reference to the UI Text element for displaying messages

    void Start()
    {
        // Find the List1.cs script in the scene
        tileListScript = FindObjectOfType<List1>();

        if (tileListScript == null)
        {
            Debug.LogError("List1 script not found in the scene!");
            return;
        }

        StartCoroutine(SpawnModifiers());
    }

    IEnumerator SpawnModifiers()
    {
        while (true)
        {
            if (activeModifiers.Count < 10) // Limit active modifiers to 6
            {
                // Get a random tile to spawn the modifier on
                GameObject tile = GetRandomTile();
                if (tile != null)
                {
                    // Instantiate a random modifier prefab
                    GameObject modifierPrefab = modifierPrefabs[Random.Range(0, modifierPrefabs.Length)];
                    GameObject modifier = Instantiate(modifierPrefab);

                    modifier.transform.position = tile.transform.position;

                    // Set the message text reference for the modifier
                    Modifier1 mod1 = modifier.GetComponent<Modifier1>();
                    if (mod1 != null)
                    {
                        mod1.modifierMessageText = modifierMessageText;
                    }

                    Modifier2 mod2 = modifier.GetComponent<Modifier2>();
                    if (mod2 != null)
                    {
                        mod2.modifierMessageText = modifierMessageText;
                    }

                    // Add modifier to active list and occupied tile set
                    activeModifiers.Add(modifier);
                    occupiedTiles.Add(tile);

                    // Start coroutine to remove the modifier after 20 seconds
                    StartCoroutine(RemoveModifierAfterTime(modifier, tile, 20f));
                }
            }

            // Wait for a certain interval before spawning another modifier
            yield return new WaitForSeconds(5f); // Adjust spawn interval as needed
        }
    }

    GameObject GetRandomTile()
    {
        List<GameObject> availableTiles = new List<GameObject>();
        foreach (GameObject tile in tileListScript.tileObjects)
        {
            if (!occupiedTiles.Contains(tile) && !excludedTileNames.Contains(tile.name))
            {
                availableTiles.Add(tile);
            }
        }

        if (availableTiles.Count == 0)
        {
            Debug.LogWarning("No available tiles to spawn a modifier!");
            return null;
        }

        // Get a random tile from the list of available tiles
        int randomIndex = Random.Range(0, availableTiles.Count);
        return availableTiles[randomIndex];
    }

    IEnumerator RemoveModifierAfterTime(GameObject modifier, GameObject tile, float time)
    {
        yield return new WaitForSeconds(time);

        // Remove the modifier from the list of active modifiers
        activeModifiers.Remove(modifier);
        occupiedTiles.Remove(tile);

        // Move the modifier off-screen and destroy it
        modifier.transform.position = offScreenTransform.position;
        //Destroy(modifier);
    }
}
