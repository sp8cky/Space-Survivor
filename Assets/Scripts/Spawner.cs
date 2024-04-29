using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> objectsToSpawn;
    private float interval = 2;
    float timer;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= interval) {
            // Random choice of object list
            int randomIndex = UnityEngine.Random.Range(0, objectsToSpawn.Count);
            GameObject objectPrefab = objectsToSpawn[randomIndex];

            // Instantiate object
            Instantiate(objectPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), objectPrefab.transform.rotation);
            timer -= interval;
        }
    }
}