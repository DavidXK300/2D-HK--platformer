using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private float speed;

    public Vector2 moveInput;
    private float JumpingSpeed = 6f;


    float horizontalMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      

    
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpingSpeed);
        }
    }
    void FixedUpdate()
    {
        float targetSpeed = moveInput.x * speed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);
    }



    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
 }


