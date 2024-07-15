using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float shootSpeed = 10f;
    public float fireRate = 0.2f;

    private float originalFireRate;
    private float originalMoveSpeed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        originalFireRate = fireRate;
        originalMoveSpeed = moveSpeed;
    }

    void Update() {
        MovePlayer();
        if (Input.GetMouseButtonDown(0)) {
            ShootBullet();
        }
    }

    // MOVEMENT //////////////////////////////////////////////////////////////////////////////

    private void MovePlayer() {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void StopPlayerMovement() {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    // HEALTH AND SPEED //////////////////////////////////////////////////////////////////////////////

    public void GainHealth(float amount) { GameManager.instance.IncreasePlayerHealth(amount); }
    public void LoseHealth(float amount) { GameManager.instance.DecreasePlayerHealth(amount); }
    public void ChangePlayerAttributes(float? newSpeed, float? newFireRate, float duration) {
        if (newSpeed.HasValue) {
            StartCoroutine(ChangeMoveSpeedTemporarily(newSpeed.Value, duration));
        } else if (newFireRate.HasValue) {
            StartCoroutine(ChangeFireRateTemporarily(newFireRate.Value, duration));
        }
    }

    IEnumerator ChangeMoveSpeedTemporarily(float newSpeed, float duration) {
        moveSpeed = newSpeed;
        Debug.Log("Speed changed to " + moveSpeed);
        while (duration > 0) {
            duration -= Time.deltaTime;
            UIManager.instance.UpdateSpeedText((int)duration);
            yield return null;
        }
        UIManager.instance.UpdateSpeedText(-1);
        moveSpeed = originalMoveSpeed;
    }

    IEnumerator ChangeFireRateTemporarily(float newFireRate, float duration) {
        fireRate = newFireRate;
        Debug.Log("Fire rate changed to " + fireRate);
        while (duration > 0) {
            duration -= Time.deltaTime;
            UIManager.instance.UpdateShootText((int)duration);
            yield return null;
        }
        UIManager.instance.UpdateShootText(-1);
        fireRate = originalFireRate;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Collision detection when player hits an enemy
        if (other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            LoseHealth(1);
            StopPlayerMovement(); // Stop the player's movement if a collision with an opponent occurs
        }

        if (other.gameObject.CompareTag("Item")) {
            Destroy(other.gameObject);
            StopPlayerMovement();
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
