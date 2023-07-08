using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float characterSpeed;
    public Rigidbody2D rb2d;
    public GameObject hitbox;

    public override void Update()
    {
        base.Update();
        //Debug.Log("woo");

        MoveLeft();
        UpdateLocalHitboxPosition();
    }

    private void UpdateLocalHitboxPosition()
    {
        if (hitbox != null)
        {
            hitbox.transform.localPosition = Vector3.zero;
        }
    }


    void MoveLeft()
    {
        MoveInDirection(-1f, 0f);
    }

    void MoveRight()
    {
        MoveInDirection(1f, 0f);
    }

    void MoveUp()
    {
        MoveInDirection(0f, 1f);
    }

    void MoveDown()
    {
    }

    void MoveInDirection(float xDir, float yDir)
    {
        Orient(xDir, yDir);
        HandleAnimation(xDir, yDir);
        Vector2 velocity = new Vector2(xDir * characterSpeed, yDir * characterSpeed);
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
        transform.position = rb2d.position + velocity * Time.fixedDeltaTime;
    }



    private void HandleAnimation(float movementX, float movementY)
    {
        if (GetComponent<Character>().CurrState == Character.CharState.HURT)
        {
            return;
        }

        Character.CharState stateToUpdateTo =
            (movementX == 0 && movementY == 0) ? Character.CharState.IDLE : Character.CharState.MOVING;

        SetState(stateToUpdateTo);
    }

}
