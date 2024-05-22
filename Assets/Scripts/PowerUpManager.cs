using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab; // Reference to the power-up prefab
    public float spawnInterval = 10f; // Time interval between spawns
    public int maxPowerUps = 1; // Maximum number of power-ups allowed to be active at the same time
    private List<GameObject> activePowerUps = new List<GameObject>(); // List to track active power-ups

    public List1 list1; // Reference to the List1 script



    public void Start()
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
        int counter = 0;
        while (counter < 6)
        {

            yield return new WaitForSeconds(spawnInterval);

            if (activePowerUps.Count < maxPowerUps)
            {
                SpawnPowerUp();
                counter++;
            }
            else
            {
                yield return new WaitForSeconds(spawnInterval);

            }
        }
    }


    void SpawnPowerUp()
    {

        
         {
             Debug.LogWarning("No tiles available for spawning power-ups.");
             return;
         }

         // Get a random tile to spawn the power-up on
         int randomIndex = Random.Range(0, list1.tileObjects.Count);
         GameObject randomTile = list1.tileObjects[randomIndex];

         // Check if a power-up is already on this tile
        
         foreach (GameObject powerUp in activePowerUps)
         {
             if (powerUp != null && powerUp.transform.position == randomTile.transform.position)
             {
                 
                 break;
             }
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