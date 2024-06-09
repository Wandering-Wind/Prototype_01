using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    int randomNum_1;
    int randomNum_2;

    [SerializeField]
    public Transform boardParent; //reference to the parent of the tiles

    Transform Tile1;
    Transform Tile2;

    [SerializeField]
    public GameObject powerUp_prefab;

    public int num_powerups = 5;

    // Start is called before the first frame update
    void Start()
    {
        //finds a random number from the list of tiles (excluding the first and last. Lists start at 0 so the tiles would be 0-48).

       for (int i = 0;i<num_powerups;i++){
            //get a random number from 1 to 47
            int r = Random.Range(1, 47);
            //Get reference to the tile so we can work with it
            Transform tile = boardParent.GetChild(r);
            //Do some wizardry by Taytay
            Instantiate(powerUp_prefab, tile.position, tile.rotation, this.transform);
           
            this.transform.GetChild(i).gameObject.SetActive(true);
            Debug.Log("Instantiation code"); //checking
        }
      

      
    }
}
