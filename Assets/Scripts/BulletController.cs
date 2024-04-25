using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Bullet with Wall");
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision Bullet with Enemy");
            GameManager.instance.IncreaseScore(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
