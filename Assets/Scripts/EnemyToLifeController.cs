using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoLifeController : EnemyController {

    protected override void Start() {
        base.Start();
        maxHealth = 2;
        currentHealth = maxHealth;
    }
}
