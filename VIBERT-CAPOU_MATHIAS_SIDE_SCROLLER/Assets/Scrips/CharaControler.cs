using UnityEngine;

public class CharaControler : MonoBehaviour
{
    [Header("Move variable")]
    [SerializeField] float movespeed = 5f;
    [SerializeField] float acceleration = 20f;

    [Header("Gravity/Jump")]
    [SerializeField] float gravity = -10f;
    [SerializeField] float jumpForce = 1.5f;

    Rigidbody2D rb;
    float inputX;
    public LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded) rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpForce);


        /*
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
        */
    }

    void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = inputX * movespeed;

        rb.linearVelocity = v;
        //rb.linearVelocity = input * movespeed;
    }
}
