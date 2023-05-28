using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameObject gameController;
    private GameLoop gameLoop;
    public Camera sceneCamera;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private GameObject meleeItem, rangedItem, punchItem;
    private MeleeBehaviour meleeBehaviour, punchBehaviour;
    private RangedBehaviour rangedBehaviour;
    [SerializeField]
    private Animator anim;
    public Player player;
    
    public GameObject healthBarUI;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        slider.value = (player.getHealth());
        if(player.getHealth() <= 0)
        {
            //Player is dead | Do something

        }
    }

    void Start()
    {
        //gameLoop = gameController.GetComponent<GameLoop>();
        //player = new Player();
        //sceneCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    //called on set amount of time physics shit
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (!gameLoop.InWorkshop())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (meleeItem.activeSelf)
                {
                    if (meleeBehaviour.Fire())
                    {
                        anim.Play("SwingBat");
                    }
                }
                else
                {
                    if (punchBehaviour.Fire())
                    {
                        anim.Play("Punch");
                    }
                }
            }

            if (Input.GetMouseButtonDown(1) && rangedItem.activeSelf)
            {
                if (rangedBehaviour.Fire())
                {
                    anim.Play("Punch");
                }
            }
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //Rotate player to follow mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    public void SetMelee(GameObject melee)
    {
        meleeItem = melee;
        meleeBehaviour = melee.GetComponent<MeleeBehaviour>();
    }
    public void SetPunch(GameObject punch)
    {
        punchItem = punch;
        punchBehaviour = punch.GetComponent<MeleeBehaviour>();
    }

    public float CalculatedHealth(int damage)
    {
        return player.TakeDamage(damage); // This gets health as a percentage 
    }


    public void SetRanged(GameObject ranged)
    {
        rangedItem = ranged;
        rangedBehaviour = ranged.GetComponent<RangedBehaviour>();
    }

    public void SetCamera(GameObject camera)
    {
        sceneCamera = camera.GetComponent<Camera>();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    public void SetGameLoop(GameLoop gameLoop)
    {
        this.gameLoop = gameLoop;
    }



}
