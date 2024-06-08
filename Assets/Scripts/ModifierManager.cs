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
            if (activeModifiers.Count < 6)
            {
                GameObject modifier = Instantiate(modifiers[Random.Range(0, modifiers.Length)], offScreenTransform.position, Quaternion.identity);
                GameObject tile = tiles[Random.Range(0, tiles.Count)];
                modifier.transform.position = tile.transform.position;
                activeModifiers.Add(modifier);
                StartCoroutine(RemoveModifierAfterTime(modifier, 20f));
            }
            yield return new WaitForSeconds(5f); // Adjust spawn interval as needed
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
