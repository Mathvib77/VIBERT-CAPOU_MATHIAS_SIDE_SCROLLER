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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded) rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = RunSpeed;
        }
        else
        {
            currentSpeed = WalkSpeed;
        }


        /*
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        */
    }

    void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = inputX * currentSpeed;

        

        rb.linearVelocity = v;
        //rb.linearVelocity = input * movespeed;
    }

}
