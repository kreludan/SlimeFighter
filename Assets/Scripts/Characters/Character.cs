using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject spawner;

    [SerializeField]
    private GameObject hurtbox;

    [SerializeField]
    private float spawnPosnValue;

    [SerializeField]
    private int attackCooldownFrames;

    [SerializeField]
    private int recoveryFrames;
    public int RecoveryFrames => recoveryFrames;

    public enum CharDirX
    {
        LEFT, RIGHT, NEUTRAL
    }
    public enum CharDirY
    {
        UP, DOWN, NEUTRAL
    }

    private CharDirX prevDirX;
    private CharDirX dirX;
    public CharDirX DirX => dirX;
    private CharDirY dirY;
    public CharDirY DirY => dirY;

    private int currHurtRecoveryFrames;

    public enum CharState
    {
        IDLE, MOVING, HURT, DEAD
    }

    private CharState prevState;
    private CharState state;
    public CharState CurrState => state;

    // Start is called before the first frame update
    void Start()
    {
        dirX = CharDirX.LEFT;
        dirY = CharDirY.NEUTRAL;

        prevState = CharState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner) UpdateSpawnerPosition();
        UpdateHurtboxPosition();

        if(state != prevState)
        {
            // Debug.Log("Went from " + prevState + " to " + state);
            if(state == CharState.MOVING)
            {
                GetComponent<Animator>().Play("Move");
            }
            else if(state == CharState.IDLE)
            {
                GetComponent<Animator>().Play("Idle");
            }
        }

        prevState = state;

        if(dirX == CharDirX.LEFT)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(dirX == CharDirX.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        prevDirX = dirX;

        if (currHurtRecoveryFrames > 0)
        {
            Color c = GetComponent<SpriteRenderer>().color;
            c.a = 0.6f;
            GetComponent<SpriteRenderer>().color = c;
            currHurtRecoveryFrames -= 1;
            if(currHurtRecoveryFrames == 0)
            {
                c = GetComponent<SpriteRenderer>().color;
                c.a = 1f;
                GetComponent<SpriteRenderer>().color = c;
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " Died ):");
        }
    }

    public void SetState(CharState newState)
    {
        state = newState;
    }

    private void UpdateHurtboxPosition()
    {
        if(hurtbox != null)
        {
            hurtbox.transform.localPosition = Vector3.zero;
        }
    }
    private void UpdateSpawnerPosition()
    {
        Vector3 spawnerPosn = new Vector3();
        spawnerPosn.x = dirX switch
        {
            CharDirX.RIGHT => spawnPosnValue,
            CharDirX.LEFT => -spawnPosnValue,
            _ => 0
        };
        spawnerPosn.y = dirY switch
        {
            CharDirY.UP => spawnPosnValue,
            CharDirY.DOWN => -spawnPosnValue,
            _ => 0
        };
        spawner.transform.localPosition = spawnerPosn;
    }

    public void Orient(float xOrient, float yOrient)
    {
        if (xOrient == 0 && yOrient == 0)
        {
            return;
        }
        else
        {
            dirX = xOrient == 0 ? CharDirX.NEUTRAL : (xOrient > 0 ? CharDirX.RIGHT : CharDirX.LEFT);
            dirY = yOrient == 0 ? CharDirY.NEUTRAL : (yOrient > 0 ? CharDirY.UP : CharDirY.DOWN);
        }
    }


    public void TakeDamage(int damage)
    {
        if(currHurtRecoveryFrames > 0) { return; }
        GlobalManager.Instance.UiManager.BattleUI.HealthUpdate(health);
        health -= 1;
        HandleHurt();
    }

    private void HandleHurt()
    {
        currHurtRecoveryFrames = recoveryFrames;
        GetComponent<Animator>().Play("Hurt");
    }

}
