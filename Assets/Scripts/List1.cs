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
                Debug.LogWarning("Not enough GameObjects in tileObjects list.");//tile checks
                break;
            }
        }
    }

    void Start()
    {
        if (tiles.Count == 0)
        {
            Debug.LogWarning("The list of tiles is empty. Please assign strings.");//tile checks
        }

        AssignTileObjects();

        // Moves the GameObject associated with Tile2
        MoveTile("Tile10", new Vector3(0.25f, 0f, 0f)); // Adjusts the tile which needs to change, we should adjust it so that the player can choose the tile they want to change
    }

    GameObject GetGameObjectByString(string tileName) //finds game object by string
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


