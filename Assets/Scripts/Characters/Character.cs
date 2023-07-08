using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject spawner;

    [SerializeField]
    private float spawnPosnValue;

    private enum CharDirX
    {
        LEFT, RIGHT, NEUTRAL
    }
    private enum CharDirY
    {
        UP, DOWN, NEUTRAL
    }

    private CharDirX dirX;
    private CharDirY dirY;


    // Start is called before the first frame update
    void Start()
    {
        dirX = CharDirX.RIGHT;
        dirY = CharDirY.NEUTRAL;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner) UpdateSpawnerPosition();

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " Died ):");
        }
    }

    private void UpdateSpawnerPosition()
    {
        Vector3 spawnerPosn = new Vector3();
        spawnerPosn.x = dirX switch
        {
            CharDirX.RIGHT => spawnPosnValue,
            CharDirX.LEFT => -spawnPosnValue,
            _ => 0
        };
        spawnerPosn.y = dirY switch
        {
            CharDirY.UP => spawnPosnValue,
            CharDirY.DOWN => -spawnPosnValue,
            _ => 0
        };
        spawner.transform.localPosition = spawnerPosn;
    }

    public void Orient(float xOrient, float yOrient)
    {
        if (xOrient == 0 && yOrient == 0)
        {
            return;
        }
        else
        {
            dirX = xOrient == 0 ? CharDirX.NEUTRAL : (xOrient > 0 ? CharDirX.RIGHT : CharDirX.LEFT);
            dirY = yOrient == 0 ? CharDirY.NEUTRAL : (yOrient > 0 ? CharDirY.UP : CharDirY.DOWN);
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }

}
