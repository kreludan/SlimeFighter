using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEnemy : Enemy
{
    public int walkCycleLength = 120;
    public bool doneAttack;

    private int frameNumTracker;
    private bool moveTowards;

    // Start is called before the first frame update
    void Start()
    {
        moveTowards = true;
        doneAttack = false;
        frameNumTracker = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (frameNumTracker <= walkCycleLength)
        {
            if (moveTowards)
            {
                MoveDirPlayer();
            }
            else
            {
                MoveAwayPlayer();
            }

            frameNumTracker++;
        }
        else if (doneAttack == false)
        {
            MoveInDirection(0, 0);
        }
        else
        {
            moveTowards = !moveTowards;
            frameNumTracker = 0;
            doneAttack = false;
        }

    }
}
