using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject bulletPrefab;
    public float speed = 5f;
    public float shootSpeed = 10f;
    private int maxHealth;
    private int currentHealth;

    void Start() { maxHealth = GameManager.instance.GetPlayerHealth(); }

    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
        if (Input.GetKeyDown(KeyCode.Mouse0)) ShootBullet(); // Shoot
    }

    public void GainHealth(int amount) {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        GameManager.instance.IncreasePlayerHealth(amount);
    }

    public void IncreaseAttackSpeed(int amount) { shootSpeed += amount; }
    
    public void LoseHealth(int amount) {
        currentHealth -= amount;
        GameManager.instance.DecreasePlayerHealth(amount);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Collision detection when player hits an enemy
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision Player with Enemy");
            Destroy(other.gameObject);
            LoseHealth(1);

            // Stop the player's movement if a collision with an opponent occurs
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void ShootBullet() {
        // Create an instance of the ball at the player's position (transform.position)
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        
        // Add a force to shoot the ball upwards
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, shootSpeed);
    }
}