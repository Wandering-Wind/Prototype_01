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

        // Move the GameObject associated with Tile2
        MoveTile("Tile2", new Vector3(2f, 0f, 0f)); // Adjust the Vector3 as needed
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

    void MoveTile(string tileName, Vector3 newPosition)
    {
        GameObject tileObject = GetGameObjectByString(tileName);
        if (tileObject != null)
        {
            tileObject.transform.position = newPosition;
            Debug.Log("Moved " + tileName + " to position: " + newPosition);
        }
        else
        {
            Debug.LogWarning("Tile " + tileName + " not found.");
        }
    }

    void Update()
    {

    }
}


