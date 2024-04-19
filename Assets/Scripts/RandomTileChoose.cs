using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTileChoose : MonoBehaviour
{
    public Transform[] tiles;
    public float InvokeRate = 1.0f;
    public GameObject Square1;
    
        void Start()
    {
        InvokeRepeating("pickpoints", 1.0f, InvokeRate);
    }

   
    void picktiles()
    {
      int indexNumber =  Random.Range(0,tiles.Length);
        Debug.Log(tiles[indexNumber].name);
    }
}
