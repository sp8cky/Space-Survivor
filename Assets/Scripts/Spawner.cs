using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> objectsToSpawn;
    public List<GameObject> itemsToSpawn;
    public float interval = 2;
    public float itemSpawnChance = 0.3f;
    private float timer;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= interval) {
            // Zufälliges Objekt zum Spawnen auswählen
            GameObject objectPrefab = GetRandomObjectToSpawn();

            // Objekt spawnen
            Instantiate(objectPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), objectPrefab.transform.rotation);
            timer -= interval;

            // Überprüfen, ob ein Health-Item gespawnt werden soll
            if (UnityEngine.Random.value < itemSpawnChance) SpawnItems();
        }
    }

    // Zufällige Auswahl eines Objekts aus der Liste
    private GameObject GetRandomObjectToSpawn() { return objectsToSpawn[UnityEngine.Random.Range(0, objectsToSpawn.Count)]; }

    // Zusätzliche Items spawnen
    private void SpawnItems() { //TODO: fix that attack speed gets higer and timer
        GameObject itemPrefab = itemsToSpawn[UnityEngine.Random.Range(0, itemsToSpawn.Count)];
        Instantiate(itemPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), itemPrefab.transform.rotation);
    }
}