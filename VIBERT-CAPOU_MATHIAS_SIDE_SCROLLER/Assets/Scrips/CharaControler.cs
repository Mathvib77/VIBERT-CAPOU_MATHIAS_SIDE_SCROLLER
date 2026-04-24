using UnityEngine;

public class CharaControler : MonoBehaviour
{
    [Header("Move variable")]
    [SerializeField] float WalkSpeed = 5f;
    [SerializeField] float RunSpeed = 10f;

    private float currentSpeed;
    Rigidbody2D rb;
    private Vector2 movement;
    //[SerializeField] float acceleration = 20f;

    [Header("Gravity/Jump")]
    [SerializeField] float gravity = -10f;
    [SerializeField] float jumpForce = 1.5f;

    float inputX;
    public LayerMask groundLayer;

    bool isGrounded = false;

    Animator animator;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            if (animator != null) animator.SetBool("isJumping", true);
        }

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? RunSpeed : WalkSpeed;

        if (animator != null)
        {
            if (!isGrounded)
            {
                animator.SetFloat("Speed", 0f);
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetFloat("Speed", Mathf.Abs(inputX));
                animator.SetBool("IsRunning", isRunning);
            }
            if (isGrounded) animator.SetBool("isJumping", false);
        }


        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    currentSpeed = RunSpeed;
       // }
        //else
        //{
           // currentSpeed = WalkSpeed;
        //}

    }

    void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = inputX * currentSpeed;

        rb.linearVelocity = v;
        //rb.linearVelocity = input * movespeed;
    }

}
