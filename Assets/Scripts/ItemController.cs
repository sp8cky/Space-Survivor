using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
    public float fallSpeed = 4f; 

    private Rigidbody2D rb;

    private void Start() {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    private void Update() {
        rb.velocity = new Vector2(0, -fallSpeed);
    }
}
