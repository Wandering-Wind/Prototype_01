using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public GameObject[] modifierPrefabs; // Array of modifier prefabs
    public List1 tileListScript; // Reference to List1.cs script
    public Transform offScreenTransform; // Location to hide unused modifiers

    private List<GameObject> activeModifiers = new List<GameObject>();
    private HashSet<GameObject> occupiedTiles = new HashSet<GameObject>();

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



            if (activeModifiers.Count < 6) // Limit active modifiers to 6
            {
                // Get a random tile to spawn the modifier on
                GameObject tile = GetRandomTile();
                if (tile != null)
                {
                    // Instantiate a random modifier prefab
                    GameObject modifierPrefab = modifierPrefabs[Random.Range(0, modifierPrefabs.Length)];
                    GameObject modifier = Instantiate(modifierPrefab);

                    modifier.transform.position = tile.transform.position;

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
            if (!occupiedTiles.Contains(tile))
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
        Destroy(modifier);
    }
}

/*finds a random number from the list of tiles (excluding the first and last. Lists start at 0 so the tiles would be 0-48).

for (int i = 0; i < num_powerups; i++)
{
    //get a random number from 1 to 47
    int r = Random.Range(1, 47);
    //Get reference to the tile so we can work with it
    Transform tile = boardParent.GetChild(r);
    //Do some wizardry by Taytay
    Instantiate(powerUp_prefab, tile.position, tile.rotation, this.transform);

    this.transform.GetChild(i).gameObject.SetActive(true);
    Debug.Log("Instantiation code"); //checking
    }
    */


