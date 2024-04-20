using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List1 : MonoBehaviour
{
    public List<string> tiles = new List<string>(); // Make it public if you want to assign GameObjects in the Unity Inspector
    public List<GameObject> tileObjects = new List<GameObject>(); // List to store existing game objects associated with tiles

    // Assign GameObjects to corresponding strings in the list
    void AssignTileObjects()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (i < tileObjects.Count) // Make sure there are enough GameObjects in the tileObjects list
            {
                tileObjects[i].name = tiles[i]; // Assign the string as the name of the GameObject
            }
            else
            {
                Debug.LogWarning("Not enough GameObjects in tileObjects list.");
                break;
            }
        }
    }

    void Start()
    {
        // Populate the list of strings (if not assigned in the Unity Inspector)
        if (tiles.Count == 0)
        {
            Debug.LogWarning("The list of tiles is empty. Please assign strings.");
        }

        // Call the method to assign GameObjects to strings
        AssignTileObjects();

        // Access the GameObject associated with a specific tile
        Debug.Log("Game object associated with Tile2: " + GetGameObjectByString("Tile2").name);
    }

    // Method to get the game object associated with a specific string
    GameObject GetGameObjectByString(string tileName)
    {
        GameObject foundObject = null;
        foreach (GameObject obj in tileObjects)
        {
            if (obj.name == tileName)
            {
                foundObject = obj;
                break;
            }
        }
        return foundObject;
    }

    void Update()
    {

    }
}


