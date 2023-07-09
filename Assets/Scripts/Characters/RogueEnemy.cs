using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueEnemy : Enemy
{
    public int walkCycleLength = 80;
    public bool doneAttack;

    private int frameNumTracker;

    private GameObject attackToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        doneAttack = false;
        frameNumTracker = 0;
        attackToSpawn = null;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        GameObject player = GameObject.Find("Player");
        if (transform.position.x < player.transform.position.x)
        {
            Orient(1, 0);
        }
        else
        {
            Orient(-1, 0);
        }


        if (frameNumTracker <= walkCycleLength)
        {
            MoveVerticalDirPlayer();
            frameNumTracker++;
        }
        else if (doneAttack == false)
        {
            MoveInDirection(0, 0);
        }
        else
        {
            frameNumTracker = 0;
            doneAttack = false;
        }

    }
}
