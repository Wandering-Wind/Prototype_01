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
        MoveTile("Tile.zero", new Vector3(0.25f, 0f, 0f)); // Adjusts the tile which needs to change, we should adjust it so that the player can choose the tile they want to change
    }

<<<<<<< Updated upstream
    GameObject GetGameObjectByString(string tileName) //finds game object by string
    {
        GameObject foundObject = null;
=======
    IEnumerator DestroyTilesSequence() //Function to destry tiles in a sequence
    {                                  //provides methods to change and effect collections, it was easier to apply that a time was
        //yes there is a better way to do this code (;-;)
        yield return new WaitForSeconds(10000000f);
        DestroyTiles(new List<string> { "Tile1", "Tile2", "Tile3", "Tile4","Tile5", "Tile6", "Tile7", "Tile8", "Tile14", "Tile15", "Tile21", "Tile22", "Tile28", "Tile29", "Tile", "Tile35", "Tile36", "Tile42", "Tile43", "Tile44", "Tile45", "Tile46", "Tile47", "Tile48", "Tile49" });

       
        yield return new WaitForSeconds(10000000f);
        DestroyTiles(new List<string> { "Tile9", "Tile10", "Tile11", "Tile12", "Tile13", "Tile16","Tile20", "Tile23","Tile27","Tile30", "Tile34", "Tile37","Tile38","Tile39", "Tile40","Tile41" });

        
        yield return new WaitForSeconds(10000000f);
        DestroyTiles(new List<string> { "Tile17", "Tile18", "Tile19" ,"Tile24" , "Tile26" ,"Tile27","Tile31","Tile32","Tile33" });

       
    }

    GameObject GetGameObjectByString(string tileName) //gets gameobject by string
    {                                                 // getsobject by string used 
>>>>>>> Stashed changes
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


