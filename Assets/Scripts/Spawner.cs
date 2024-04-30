using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> objectsToSpawn;
    public float interval = 2;
    public float healthItemSpawnChance = 0.3f;
    private float timer;

    public GameObject healthItemPrefab;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= interval) {
            // random object to spawn
            GameObject objectPrefab = GetRandomObjectToSpawn();

            // Spawnen des Objekts
            Instantiate(objectPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), objectPrefab.transform.rotation);
            timer -= interval;

            // Check if health item should be spawned
            if (UnityEngine.Random.value < healthItemSpawnChance) {
                GameObject healthItemPrefab = GetHealthItemPrefab();
                Instantiate(healthItemPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), healthItemPrefab.transform.rotation);
            }
        }
    }

    // Random choice of object from list
    private GameObject GetRandomObjectToSpawn() {
        int randomIndex = UnityEngine.Random.Range(0, objectsToSpawn.Count);
        return objectsToSpawn[randomIndex];
    }

    private GameObject GetHealthItemPrefab() {
        return healthItemPrefab;
    }

}