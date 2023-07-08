using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float universalCharacterSpeed;
    
    private enum Wall { LEFT, RIGHT, UPPER, LOWER};

    private Dictionary<Wall, bool> hitWall;

    // Start is called before the first frame update
    void Start()
    {
        hitWall = new Dictionary<Wall, bool>
        {
            [Wall.LEFT] = false,
            [Wall.RIGHT] = false,
            [Wall.UPPER] = false,
            [Wall.LOWER] = false
        };
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            GetComponent<Animator>().Play("Attack");
            if(GetComponentInParent<Spawner>() != null)
            {
                GetComponentInParent<Spawner>().SpawnAttack(GetComponentInParent<Character>().DirX, GetComponentInParent<Character>().DirY);
            }
        }
    }

    private void HandleMovement()
    {
        Vector3 p = transform.position;
        float characterDirectionX = 0;
        float characterDirectionY = 0;

        if (Input.GetKey(KeyCode.A)) characterDirectionX -= 1;
        if (Input.GetKey(KeyCode.D)) characterDirectionX += 1;

        if (Input.GetKey(KeyCode.W)) characterDirectionY += 1;
        if (Input.GetKey(KeyCode.S)) characterDirectionY -= 1;

        if (characterDirectionX != 0 && characterDirectionY != 0)
        {
            float rad2Over2 = Mathf.Sqrt(2) / 2;
            characterDirectionX *= rad2Over2;
            characterDirectionY *= rad2Over2;
        }

        GetComponent<Character>().Orient(characterDirectionX, characterDirectionY);

        if (characterDirectionX > 0 && hitWall[Wall.RIGHT] || characterDirectionX < 0 && hitWall[Wall.LEFT])
            characterDirectionX = 0;

        if (characterDirectionY > 0 && hitWall[Wall.UPPER] || characterDirectionY < 0 && hitWall[Wall.LOWER])
            characterDirectionY = 0;

        p.x += characterDirectionX * universalCharacterSpeed;
        p.y += characterDirectionY * universalCharacterSpeed;

        transform.position = p;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("LeftWall")) hitWall[Wall.LEFT] = true;
        if (collision.name.Contains("RightWall")) hitWall[Wall.RIGHT] = true;
        if (collision.name.Contains("UpperWall")) hitWall[Wall.UPPER] = true;
        if (collision.name.Contains("LowerWall")) hitWall[Wall.LOWER] = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("LeftWall")) hitWall[Wall.LEFT] = false;
        if (collision.name.Contains("RightWall")) hitWall[Wall.RIGHT] = false;
        if (collision.name.Contains("UpperWall")) hitWall[Wall.UPPER] = false;
        if (collision.name.Contains("LowerWall")) hitWall[Wall.LOWER] = false;

    }
}
