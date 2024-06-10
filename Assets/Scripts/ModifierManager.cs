using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public GameObject[] modifiers; // Array of modifier prefabs
    public List<GameObject> tiles; // List of tile objects
    public Transform offScreenTransform; // Location to hide unused modifiers

    private List<GameObject> activeModifiers = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnModifiers());
    }

    IEnumerator SpawnModifiers()
    {
        while (true)
        {
            if (activeModifiers.Count < 3)
            {
                GameObject modifier = Instantiate(modifiers[Random.Range(0, modifiers.Length)], offScreenTransform.position, Quaternion.identity);
                GameObject tile = tiles[Random.Range(0, tiles.Count)];
                modifier.transform.position = tile.transform.position;
                activeModifiers.Add(modifier);
                StartCoroutine(RemoveModifierAfterTime(modifier, 15f));
            }
            yield return new WaitForSeconds(4f); // Adjust spawn interval as needed
        }

    }

    IEnumerator RemoveModifierAfterTime(GameObject modifier, float time)
    {
        yield return new WaitForSeconds(time);
        if (modifier != null)
        {
            modifier.transform.position = offScreenTransform.position;
            activeModifiers.Remove(modifier);
            Destroy(modifier);
        }
    }
}

    /*finds a random number from the list of tiles (excluding the first and last. Lists start at 0 so the tiles would be 0-48).

    for (int i = 0; i < num_powerups; i++)
    {
        //get a random number from 1 to 47
        int r = Random.Range(1, 47);
        //Get reference to the tile so we can work with it
        Transform tile = boardParent.GetChild(r);
        //Do some wizardry by Taytay
        Instantiate(powerUp_prefab, tile.position, tile.rotation, this.transform);

        this.transform.GetChild(i).gameObject.SetActive(true);
        Debug.Log("Instantiation code"); //checking
    }
    */


