using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoLifeController : EnemyController {
    // TODO: fix, that EnemyTwoLifeController has two lifes

    protected override void Start() {
        this.maxHealth = 2;
        base.Start();
        Debug.Log("HEALTH: " + this.maxHealth);
    }
}
