using System.Collections.Generic;
using UnityEngine;

public class List1 : MonoBehaviour
{
    public float timer = 10f;
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

        // Destroy multiple blocks at once
        DestroyTiles(new List<string> { "Tile1", "Tile2", "Tile3" });
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

    void DestroyTile(string tileName)
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

    void DestroyTiles(List<string> tileNames)
    {
        foreach (string tileName in tileNames)
        {
            DestroyTile(tileName);
        }
    }

    void Update()
    {

    }
}


