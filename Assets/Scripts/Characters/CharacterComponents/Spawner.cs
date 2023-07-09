using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject attackLeft;
    public GameObject attackLower;
    public GameObject attackLowerLeft;

    public bool spawnNow;
    public bool spawnLeftNow;

    // Start is called before the first frame update
    void Start()
    {
        spawnNow = false;
        spawnLeftNow = false;
    }

    public void Update()
    {
        if(spawnNow)
        {
            Character c = GetComponentInParent<Character>();
            SpawnAttack(c.DirX, c.DirY, false);
            spawnNow = false;
        }

        if (spawnLeftNow)
        {
            Character c = GetComponentInParent<Character>();
            SpawnAttackLeft(c.DirX, c.DirY, false);
            spawnNow = false;
        }
    }

    public void SpawnAttackLeft(Character.CharDirX dirX, Character.CharDirY dirY, bool playerOwned = false)
    {
        Debug.Log(dirX);
        GameObject newProjectile = Instantiate(attackLeft, transform.position, Quaternion.identity);
        // Debug.Log(newProjectile + " is player owned? " + playerOwned);
    }

    public void SpawnAttack(Character.CharDirX dirX, Character.CharDirY dirY, bool playerOwned = false)
    {
        GameObject objectToSpawn = attackLower;
        Quaternion rotationToUse = Quaternion.identity;
        if (dirX == Character.CharDirX.NEUTRAL)
        {
            objectToSpawn = attackLower;
            rotationToUse = (dirY == Character.CharDirY.DOWN) ? Quaternion.identity : Quaternion.Euler(180, 0, 0);
        }
        else if (dirY == Character.CharDirY.NEUTRAL)
        {
            objectToSpawn = attackLeft;
            rotationToUse = (dirX == Character.CharDirX.LEFT) ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        }
        else
        {
            objectToSpawn = attackLowerLeft;
            Int32 xReflect = (dirX == Character.CharDirX.LEFT) ? 0 : 180;
            Int32 yReflect = (dirY == Character.CharDirY.DOWN) ? 0 : 180;
            rotationToUse = Quaternion.Euler(xReflect, yReflect, 0);
        }
        if(dirX == Character.CharDirX.RIGHT && dirY == Character.CharDirY.DOWN)
        {
            rotationToUse = Quaternion.Euler(0, 180, 0);
        }
        if (dirX == Character.CharDirX.LEFT && dirY == Character.CharDirY.UP)
        {
            rotationToUse = Quaternion.Euler(180, 0, 0);
        }

        GameObject newProjectile = Instantiate(objectToSpawn, transform.position, rotationToUse);
        newProjectile.GetComponent<Projectile>().playerOwned = playerOwned;
        // Debug.Log(newProjectile + " is player owned? " + playerOwned);
    }

}
