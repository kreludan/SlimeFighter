using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : Enemy
{
    public override void Update()
    {
        base.Update();
        MoveDirPlayer();
    }
}
