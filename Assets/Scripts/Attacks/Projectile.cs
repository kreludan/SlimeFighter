using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool destroyNow;
    public bool playerOwned;

    void Start()
    {
        destroyNow = false;
    }

    void Update()
    {
        if(destroyNow)
        {
            Destroy(gameObject);
        }
    }

}
