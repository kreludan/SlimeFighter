using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{

    [SerializeField]
    private BoxCollider2D box;

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(box.offset, box.size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(transform.parent.name + " collided with " + collision.transform.name);
        RespondToCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(transform.parent.name + " collided with " + collision.transform.name);
        RespondToCollision(collision);
    }

    void RespondToCollision(Collider2D collision)
    {
        if (collision.transform.parent == transform.parent || collision.transform.parent == null)
        {
            return;
        }
        // Damage dealing: (1) Player projectile hits enemy. (2) Enemy anything hits player.
        bool playerProjectileHitsEnemy =
            collision.transform.parent.GetComponent<Projectile>() != null &&
            collision.transform.parent.GetComponent<Projectile>().playerOwned &&
            !transform.parent.name.Contains("Player");
        bool enemyAnythingHitsPlayer =
            (collision.transform.parent.GetComponent<Projectile>() == null ||
            !collision.transform.parent.GetComponent<Projectile>().playerOwned) &&
            transform.parent.name.Contains("Player");

        if (collision.name.Contains("Hitbox") && (playerProjectileHitsEnemy || enemyAnythingHitsPlayer))
        {
            if (GetComponentInParent<Character>() != null && collision.GetComponentInParent<Hitbox>() != null)
            {
                GetComponentInParent<Character>().TakeDamage(collision.GetComponentInParent<Hitbox>().damage);

                if (collision.transform.parent.GetComponent<Projectile>() != null &&
                    collision.transform.parent.GetComponent<Projectile>().destroyOnContact == true)
                {
                    collision.transform.parent.GetComponent<Projectile>().destroyNow = true;
                }

                if(playerProjectileHitsEnemy)
                {
                    transform.GetComponentInParent<Enemy>().KnockbackFromPlayer(10f);
                }
                else
                {
                    transform.GetComponentInParent<CharacterController>().PlayerKnockbackFromGameobject(collision.GetComponentInParent<Transform>().position, 10f);
                }


            }
        }

        if(playerProjectileHitsEnemy)
        {
            collision.transform.parent.GetComponent<Hitbox>().enabled = false;
        }


    }
}
