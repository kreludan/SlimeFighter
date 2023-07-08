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
        Debug.Log(collision + " " + transform.parent);
        if(collision.transform.parent == transform.parent || collision.transform.parent == null)
        {
            return;
        }
        if ((collision.name.Contains("Hitbox")) &&
            (collision.transform.parent.name.Contains("Player") && !transform.parent.name.Contains("Player")) ||
            (!collision.transform.parent.name.Contains("Player") && transform.parent.name.Contains("Player")))
        {
            if (GetComponentInParent<Character>() != null)
            {
                GetComponentInParent<Character>().TakeDamage(collision.GetComponentInParent<Hitbox>().damage);
                // Debug.Log("ow " + collision.transform.parent + " " + transform.parent + " " + collision.name);
            }

        }
    }
}
