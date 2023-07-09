using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer = false;

    [SerializeField]
    public int health;

    [SerializeField]
    protected GameObject spawner;

    [SerializeField]
    private GameObject hurtbox;

    [SerializeField]
    private float spawnPosnValue;

    [SerializeField]
    private int attackCooldownFrames;

    [SerializeField]
    private int recoveryFrames;
    public int RecoveryFrames => recoveryFrames;

    public bool destroyChar;
    private bool dying;

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
        dying = false;
        destroyChar = false;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(destroyChar)
        {
            Destroy(gameObject);
            //Debug.Log(gameObject.name + " Died ):");
            if (isPlayer)
            {
                GlobalManager.Instance.UiManager.ActivateGameOverUI(true);
            }
        }

        if (dying) return;

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
            dying = true;
            //Debug.Log("Dying");
            GetComponent<Animator>().Play("Death");
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
        float spawnValX = spawnPosnValue;
        float spawnValY = spawnPosnValue;
        if (!(dirX == CharDirX.NEUTRAL || dirY == CharDirY.NEUTRAL))
        {
            spawnValX -= 0.2f;
            spawnValY -= 0.3f;
        }
        spawnerPosn.x = dirX switch
        {
            CharDirX.RIGHT => spawnValX,
            CharDirX.LEFT => -spawnValX,
            _ => 0
        };
        spawnerPosn.y = dirY switch
        {
            CharDirY.UP => spawnValY,
            CharDirY.DOWN => -spawnValY,
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

    public void setDirX(CharDirX chardir)
    {
        dirX = chardir;
    }

    public void TakeDamage(int damage)
    {
        if(currHurtRecoveryFrames > 0) { return; }
        health -= 1;
        if(isPlayer) GlobalManager.Instance.UiManager.BattleUI.HealthUpdate(health);
        HandleHurt();
    }

    private void HandleHurt()
    {
        currHurtRecoveryFrames = recoveryFrames;
        GetComponent<Animator>().Play("Hurt");
    }

}
