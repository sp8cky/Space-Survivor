using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoLifeController : EnemyController {
    // TODO: fix, that EnemyTwoLifeController has two lifes

    protected override void Start() {
        base.Start();
        maxHealth = 2;
    }
}
