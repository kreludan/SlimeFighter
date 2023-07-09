using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    public int damage;

    [SerializeField]
    private BoxCollider2D box;


    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(box.offset, box.size);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name.Contains("Wall"))
        {
            if(transform.parent.GetComponent<Projectile>().destroyOnContact == true)
            {
                transform.parent.GetComponent<Projectile>().destroyNow = true;
            }
        }

        Debug.Log(transform.parent.name + " AND " + collision.transform.name);
        //Debug.Log(transform.parent.name + " collided with " + collision.transform.name);
    }

}
