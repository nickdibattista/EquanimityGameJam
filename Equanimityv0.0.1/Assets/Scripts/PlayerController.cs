using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
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
            if (melee.Fire())
            {

                anim.Play("SwingBat");
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            if (ranged.Fire())
            {
                anim.Play("Punch");
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

    public void SetMelee(MeleeBehaviour melee)
    {
        this.melee = melee;
    }

    public void SetRanged(RangedBehaviour ranged)
    {
        this.ranged = ranged;
    }

    public void SetCamera(GameObject camera)
    {
        sceneCamera = camera.GetComponent<Camera>();
    }
}
