using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float characterSpeed;
    public Rigidbody2D rb2d;
    public GameObject hitbox;
    public int waveNum;

    float diagonalUnit = Mathf.Sqrt(2) / 2;

    public override void Update()
    {
        base.Update();
        //Debug.Log("woo");

        //MoveLeft();
        //MoveDirPlayer();
        UpdateLocalHitboxPosition();
    }

    private void UpdateLocalHitboxPosition()
    {
        if (hitbox != null)
        {
            hitbox.transform.localPosition = Vector3.zero;
        }
    }

    public void MoveDirPlayer()
    {
        GameObject player = GameObject.Find("Player");
        if(player == null) { return; }
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

    public void MoveVerticalDirPlayer()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { return; }
        float yDist = player.transform.position.y - transform.position.y;
        if (Mathf.Abs(yDist) <= 0.1) yDist = 0;
        yDist = yDist != 0 ? Mathf.Sign(yDist) : 0;
        MoveInDirection(0, yDist);
    }

    public void MoveAwayPlayer(float modifier = 1)
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { return; }
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
        xDist *= modifier;
        yDist *= modifier;
        MoveInDirection(-xDist, -yDist);
    }

    public void KnockbackFromPlayer(float modifier = 1)
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { return; }
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
        xDist *= modifier;
        yDist *= modifier;
        Vector2 velocity = new Vector2(-xDist, -yDist);
        rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
        transform.position = rb2d.position + velocity * Time.deltaTime;
    }

    public void MoveLeft()
    {
        MoveInDirection(-1f, 0f);
    }

    public void MoveRight()
    {
        MoveInDirection(1f, 0f);
    }

    public void MoveUp()
    {
        MoveInDirection(0f, 1f);
    }

    public void MoveDown()
    {
        MoveInDirection(0f, -1f);
    }

    public void MoveUpLeft()
    {
        MoveInDirection(-diagonalUnit, diagonalUnit);
    }

    public void MoveUpRight()
    {
        MoveInDirection(diagonalUnit, diagonalUnit);
    }

    public void MoveDownLeft()
    {
        MoveInDirection(-diagonalUnit, -diagonalUnit);
    }

    public void MoveDownRight()
    {
        MoveInDirection(diagonalUnit, -diagonalUnit);
    }

    public void MoveInDirection(float xDir, float yDir)
    {
        Orient(xDir, yDir);
        HandleAnimation(xDir, yDir);
        Vector2 velocity = new Vector2(xDir * characterSpeed, yDir * characterSpeed);
        rb2d.MovePosition(rb2d.position + velocity * Time.deltaTime);
        transform.position = rb2d.position + velocity * Time.deltaTime;
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
