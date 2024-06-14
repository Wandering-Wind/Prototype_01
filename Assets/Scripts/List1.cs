using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class List1 : MonoBehaviour
{
    public List<string> tiles = new List<string>();
    public List<GameObject> tileObjects = new List<GameObject>();
    public string playerTag = "Playyer";

    void AssignTileObjects() //for loop to list all tiles and assign names to them
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (i < tileObjects.Count)
            {
                tileObjects[i].name = tiles[i];
            }
            else
            {
                Debug.LogWarning("tiles not found");
                break;
            }
        }
    }

    void Start()
    {
        if (tiles.Count == 0)
        {
            Debug.LogWarning("strings not assigned");
            return;
        }

        AssignTileObjects();

        StartCoroutine(DestroyTilesSequence()); //coroutine instead of timer
    }

    IEnumerator DestroyTilesSequence() //Function to destroy tiles in a sequence
    {
        yield return new WaitForSeconds(50f);
        DestroyTiles(new List<string> { "Tile1", "Tile2", "Tile3", "Tile4", "Tile5", "Tile6", "Tile7", "Tile8", "Tile14", "Tile15", "Tile21", "Tile22", "Tile28", "Tile29", "Tile", "Tile35", "Tile36", "Tile42", "Tile43", "Tile44", "Tile45", "Tile46", "Tile47", "Tile48", "Tile49" });

        yield return new WaitForSeconds(50f);
        DestroyTiles(new List<string> { "Tile9", "Tile10", "Tile11", "Tile12", "Tile13", "Tile16", "Tile20", "Tile23", "Tile27", "Tile30", "Tile34", "Tile37", "Tile38", "Tile39", "Tile40", "Tile41" });

        yield return new WaitForSeconds(50f);
        DestroyTiles(new List<string> { "Tile17", "Tile18", "Tile19", "Tile24", "Tile26", "Tile27", "Tile31", "Tile32", "Tile33" });
    }

    GameObject GetGameObjectByString(string tileName) //gets gameobject by string
    {
        foreach (GameObject obj in tileObjects)
        {
            if (obj != null && obj.name == tileName)
            {
                return obj;
            }
        }
        return null;
    }

    void DestroyTile(string tileName) //destroys tiles by name
    {
        GameObject tileObject = GetGameObjectByString(tileName);
        if (tileObject != null)
        {
            string deadPlayerName = GetPlayerOnTile(tileObject);
            if (!string.IsNullOrEmpty(deadPlayerName))
            {
                Debug.Log(deadPlayerName + " is on " + tileName + " . Player loses");
                LoseGameData.deadPlayerName = deadPlayerName;
                //Implementing the lose condition here
                SceneManager.LoadScene(3);
            }

            Destroy(tileObject);
            Debug.Log("Destroyed " + tileName);
        }
        else
        {
            Debug.LogWarning("Tile " + tileName + " not found or is already destroyed.");
        }
    }

    void DestroyTiles(List<string> tileNames)
    {
        foreach (string tileName in tileNames)
        {
            DestroyTile(tileName);
        }
    }

    string GetPlayerOnTile (GameObject tile)
    {
        Collider2D tileCollider = tile.GetComponent<Collider2D>();
        if (tileCollider != null)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(tileCollider.bounds.center, tileCollider.bounds.size, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag(playerTag))
                {
                    return collider.gameObject.name; //Return the name of the player found on the tile

                }
            }
        }
        return null; //No player found on the tile
    }

    void Update()
    {

    }
}
