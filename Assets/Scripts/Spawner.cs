using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
    private float interval = 2;
    float timer;

    void Update() {
        timer += Time.deltaTime;
        if (timer >= interval) {
            Instantiate(objectToSpawn, transform.position + new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0), objectToSpawn.transform.rotation);
            timer -= interval;
        }
    }
}