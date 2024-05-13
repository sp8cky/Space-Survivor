using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cild enemy class, this is medium enemy
public class EnemyMedium : EnemyController {

    protected override void Start() {
        base.Start();
        maxHealth = 2;
        currentHealth = maxHealth;
    }
}
