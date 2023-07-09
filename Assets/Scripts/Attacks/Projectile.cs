using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool destroyNow;
    public bool playerOwned;
    public bool isHomingProjectile;
    public bool isLinearProjectile;
    public float projectileSpeed;
    public int projectileLifetimeFrames = -999;
    public bool destroyOnContact = false;

    float diagonalUnit = Mathf.Sqrt(2) / 2;

    float linearXDist;

    void Start()
    {
        destroyNow = false;
        if(isLinearProjectile)
        {
            LinearProjectileStartBehavior();
        }
    }

    void Update()
    {
        if(isHomingProjectile)
        {
            HomingProjectileUpdateBehavior();
        }

        if(isLinearProjectile)
        {
            LinearProjectileUpdateBehavior();
        }

        if(destroyNow)
        {
            Destroy(gameObject);
        }
    }

    void HomingProjectileUpdateBehavior()
    {
        projectileLifetimeFrames -= 1;
        if(projectileLifetimeFrames < 0)
        {
            destroyNow = true;
        }

        GameObject player = GameObject.Find("Player");
        if (player == null) { Destroy(gameObject); }

        float xDist = player.transform.position.x - transform.position.x;
        float yDist = player.transform.position.y - transform.position.y;
        if (Mathf.Abs(xDist) <= 0.1) xDist = 0;
        if (Mathf.Abs(yDist) <= 0.1) yDist = 0;
        xDist = xDist != 0 ? Mathf.Sign(xDist) : 0;
        yDist = yDist != 0 ? Mathf.Sign(yDist) : 0;
        if (xDist != 0 && yDist != 0)
        {
            xDist *= diagonalUnit;
            yDist *= diagonalUnit;
        }
        MoveInDirection(xDist, yDist);
    }

    void LinearProjectileStartBehavior()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { Destroy(gameObject); }

        float xDist = player.transform.position.x - transform.position.x;
        xDist = xDist != 0 ? Mathf.Sign(xDist) : 1;
        linearXDist = xDist;
    }

    void LinearProjectileUpdateBehavior()
    {
        if(linearXDist < 0) { GetComponent<SpriteRenderer>().flipX = true; }
        MoveInDirection(linearXDist, 0);
    }

    public void MoveInDirection(float xDir, float yDir)
    {
        Vector2 velocity = new Vector2(xDir * projectileSpeed, yDir * projectileSpeed);
        Vector2 p = transform.position;
        transform.position = p + velocity * Time.deltaTime;
    }


}
