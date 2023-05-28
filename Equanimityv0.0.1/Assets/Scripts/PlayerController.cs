using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;
    private MeleeBehaviour melee;
    private RangedBehaviour ranged;
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
        player = new Player();
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

        if(Input.GetMouseButtonDown(0))
        {
            melee.Fire();
            anim.SetTrigger("SwingBat");
        }

        if(Input.GetMouseButtonDown(1))
        {
            ranged.Fire();
            anim.SetTrigger("Punch");
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

    public void SetMelee(MeleeBehaviour melee)
    {
        this.melee = melee;
    }

    public float CalculatedHealth(int damage)
    {
        return player.TakeDamage(damage); // This gets health as a percentage 
    }


    public void SetRanged(RangedBehaviour ranged)
    {
        this.ranged = ranged;
    }
}
