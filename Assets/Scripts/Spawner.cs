using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> objectsToSpawn;
    public List<GameObject> itemsToSpawn;
    public float interval = 2;
    public float itemSpawnChance = 0.1f;
    private float timer;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= interval) {
            GameObject objectPrefab = GetRandomObjectToSpawn();

            Instantiate(objectPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), objectPrefab.transform.rotation);
            timer -= interval;

            // check if item should be spawned
            if (UnityEngine.Random.value < itemSpawnChance) SpawnItems();
        }
    }

    // random object to spawn
    private GameObject GetRandomObjectToSpawn() { return objectsToSpawn[UnityEngine.Random.Range(0, objectsToSpawn.Count)]; }

    // additonal item to spawn
    private void SpawnItems() { //TODO: fix that attack speed gets higher and timer
        GameObject itemPrefab = itemsToSpawn[UnityEngine.Random.Range(0, itemsToSpawn.Count)];
        Instantiate(itemPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), itemPrefab.transform.rotation);
    }
}