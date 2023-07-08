using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float universalCharacterSpeed;

    //public bool attacking;
    //public bool endAttackNow;
    public Rigidbody2D rb2d;
    
    private enum Wall { LEFT, RIGHT, UPPER, LOWER};

    // Start is called before the first frame update
    void Start()
    {
        //attacking = false;
        //endAttackNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalManager.Instance.UiManager.PauseMenuUI.gameObject.activeSelf)
        {
            HandleMovement();
            HandleAttack();
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //attacking = true;
            //GetComponent<Animator>().Play("Attack");
            if(GetComponentInChildren<Spawner>() != null)
            {
                GetComponentInChildren<Spawner>().SpawnAttack(GetComponentInParent<Character>().DirX, GetComponentInParent<Character>().DirY, true);
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
        HandlePlayerAnimation(characterDirectionX, characterDirectionY);
        //if (attacking) return;

        Vector2 velocity = new Vector2(characterDirectionX * universalCharacterSpeed, characterDirectionY * universalCharacterSpeed);

        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
        transform.position = rb2d.position + velocity * Time.fixedDeltaTime;
    }

    private void HandlePlayerAnimation(float movementX, float movementY)
    {
        if(GetComponent<Character>().CurrState == Character.CharState.HURT)
        {
            return;
        }

        Character.CharState stateToUpdateTo =
            (movementX == 0 && movementY == 0) ? Character.CharState.IDLE : Character.CharState.MOVING;

        GetComponent<Character>().SetState(stateToUpdateTo);
    }
}
