using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject attackUpperLeft;
    public GameObject attackUpper;
    public GameObject attackUpperRight;
    public GameObject attackLeft;
    public GameObject attackRight;
    public GameObject attackLowerLeft;
    public GameObject attackLower;
    public GameObject attackLowerRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnAttack(Character.CharDirX dirX, Character.CharDirY dirY)
    {
        GameObject objectToSpawn;
        if (dirX == Character.CharDirX.LEFT)
        {
            objectToSpawn = (dirY == Character.CharDirY.UP) ? attackUpperLeft
                : (dirY == Character.CharDirY.DOWN ? attackLowerLeft : attackLeft);
        }
        else if (dirX == Character.CharDirX.RIGHT)
        {
            objectToSpawn = (dirY == Character.CharDirY.UP) ? attackUpperRight
                : (dirY == Character.CharDirY.DOWN ? attackLowerRight : attackRight);
        }
        else
        {
            objectToSpawn = (dirY == Character.CharDirY.UP) ? attackUpper : attackLower;
        }
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
