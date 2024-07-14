using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    public float speed = 5f;
    public float shootSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private Coroutine attackSpeedCoroutine;
    private Coroutine speedCoroutine;
    private float originalFireRate;
    private float originalSpeed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        originalFireRate = fireRate;
        originalSpeed = speed;
    }

    void Update() {
        MovePlayer();
        if (Input.GetMouseButton(0) && Time.time > nextFireTime) {
            ShootBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    // MOVEMENT //////////////////////////////////////////////////////////////////////////////

    private void MovePlayer() {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(inputX, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void StopPlayerMovement() {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    // HEALTH AND SPEED //////////////////////////////////////////////////////////////////////////////

    public void GainHealth(float amount) { GameManager.instance.IncreasePlayerHealth(amount); }
    public void LoseHealth(float amount) { GameManager.instance.DecreasePlayerHealth(amount); }
    public void IncreaseAttackSpeed(float amount) { 
        if (attackSpeedCoroutine != null) {
            StopCoroutine(attackSpeedCoroutine);
            fireRate = originalFireRate;
        }
        fireRate -= amount; // TOOD: fix
        attackSpeedCoroutine = StartCoroutine(ResetAttackSpeedAfterTime(10f));
    }

    public void IncreasePlayerSpeed(float amount) { 
        if (speedCoroutine != null) {
            StopCoroutine(speedCoroutine);
            speed = originalSpeed;
        }
        speed += amount;
        speedCoroutine = StartCoroutine(ResetSpeedAfterTime(10f));
    }

     private IEnumerator ResetAttackSpeedAfterTime(float time) {
        float remainingTime = time;
        while (remainingTime > 0) {
            UIManager.instance.UpdateSpeedText(remainingTime);
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        fireRate = originalFireRate;
        UIManager.instance.UpdateSpeedText(0);
    }

    private IEnumerator ResetSpeedAfterTime(float time) {
        float remainingTime = time;
        while (remainingTime > 0) {
            UIManager.instance.UpdateShootText(remainingTime);
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        speed = originalSpeed;
        UIManager.instance.UpdateShootText(0);
    }


    private void OnCollisionEnter2D(Collision2D other) {
        // Collision detection when player hits an enemy
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision Player with Enemy");
            Destroy(other.gameObject);
            LoseHealth(1);
            
            StopPlayerMovement(); // Stop the player's movement if a collision with an opponent occurs
        }

        if (other.gameObject.CompareTag("Item")) {
            Debug.Log("COLLISION Player with Item");
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
