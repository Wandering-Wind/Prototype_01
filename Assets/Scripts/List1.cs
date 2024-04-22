using System.Collections.Generic;
using UnityEngine;

public class List1 : MonoBehaviour
{
    public List<string> tiles = new List<string>();
    public List<GameObject> tileObjects = new List<GameObject>();

    void AssignTileObjects()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (i < tileObjects.Count)
            {
                tileObjects[i].name = tiles[i];
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
        if (tiles.Count == 0)
        {
            Debug.LogWarning("The list of tiles is empty. Please assign strings.");
        }

        AssignTileObjects();

        // Example of destroying multiple tiles at once
        //DestroyTiles(new List<string> { "Tile1", "Tile2" });
    }

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

    void DestroyTiles(List<string> tileNames)
    {
        foreach (string tileName in tileNames)
        {
            GameObject tileObject = GetGameObjectByString(tileName);
            if (tileObject != null)
            {
                Destroy(tileObject);
                Debug.Log("Destroyed " + tileName);
            }
            else
            {
                Debug.LogWarning("Tile " + tileName + " not found.");
            }
        }
    }

    void Update()
    {

    }
}


