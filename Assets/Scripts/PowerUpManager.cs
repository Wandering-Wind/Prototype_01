using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab; // Reference to the power-up prefab
    public float spawnInterval = 10f; // Time interval between spawns
    public int maxPowerUps = 3; // Maximum number of power-ups allowed to be active at the same time
    private List<GameObject> activePowerUps = new List<GameObject>(); // List to track active power-ups

    public List1 list1; // Reference to the List1 script

    void Start()
    {
        if (list1 == null)
        {
            Debug.LogWarning("List1 reference not set in PowerUpManager.");
            return;
        }
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (activePowerUps.Count < maxPowerUps)
            {
                SpawnPowerUp();
            }
        }
    }

    void SpawnPowerUp()
    {
        if (list1.tileObjects.Count == 0)
        {
            Debug.LogWarning("No tiles available for spawning power-ups.");
            return;
        }

        // Get a random tile to spawn the power-up on
        int randomIndex = Random.Range(0, list1.tileObjects.Count);
        GameObject randomTile = list1.tileObjects[randomIndex];

        // Check if a power-up is already on this tile
        bool tileOccupied = false;
        foreach (GameObject powerUp in activePowerUps)
        {
            if (powerUp != null && powerUp.transform.position == randomTile.transform.position)
            {
                tileOccupied = true;
                break;
            }
        }

        if (!tileOccupied)
        {
            // Spawn the power-up at the tile's position
            GameObject powerUp = Instantiate(powerUpPrefab, randomTile.transform.position, Quaternion.identity);
            activePowerUps.Add(powerUp);

            // Set the power-up's parent to keep the hierarchy organized (optional)
            powerUp.transform.SetParent(randomTile.transform);

            Debug.Log("Power-up spawned on " + randomTile.name);
        }
        else
        {
            Debug.Log("Skipped spawning power-up as the tile is already occupied.");
        }
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        if (activePowerUps.Contains(powerUp))
        {
            activePowerUps.Remove(powerUp);
            Destroy(powerUp);
            Debug.Log("Power-up removed.");
        }
    }
}
