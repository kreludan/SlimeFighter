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
        if (collision.name.Contains("Hitbox")) Debug.Log("ow");
    }

}
