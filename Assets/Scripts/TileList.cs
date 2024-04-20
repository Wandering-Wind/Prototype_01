using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour
{
    //Amina Lists
    List <string> tiles = new List <string> (49);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles.Add(tiles[i]);
            Debug.Log(tiles[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
