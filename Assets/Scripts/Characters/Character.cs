using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int health;

    private enum CharacterDirection
    {
        UP, UP_RIGHT, RIGHT, DOWN_RIGHT, DOWN, DOWN_LEFT, LEFT, UP_LEFT
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " Died ):");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }

}
