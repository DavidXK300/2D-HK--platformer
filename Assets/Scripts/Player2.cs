using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player2 : MonoBehaviour
{
    public HealthUI healthui;
   public Rigidbody2D rb;
    public float speed;
    public Vector2 moveInput;
    public float jumpForce;
    public LayerMask groundlayer;
    public Transform ground;
    public bool isJumping;
    public float lowJumpMultiplier;
    public float fallMultiplier;
    PlayerInput playerInput;

    public int health;

    public bool isInvincible;

    private Vector2 respawnpoint;
    public bool isDead; 

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        healthui.UpdateHealth(health);

        respawnpoint = transform.position;
        Debug.Log("Spawn Position" + respawnpoint);

    }
    void FixedUpdate()    
    {
        // Defines the target speed based on the move input and speed variable
        float targetSpeed = moveInput.x * speed;

        // Sets the Rigidbody2D's linear velocity to the target speed while preserving the current vertical velocity
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);

    }


    public void OnMove(InputValue value)
    {
        // Gets the move input from the InputValue and assigns it to the moveInput variable
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value) 
    {

        // Checks if the jump button is pressed and the player is grounded
        if (value.isPressed && isGrounded()) 
        {
            // Sets the Rigidbody2D's linear velocity to the jump force while preserving the current horizontal velocity
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;

        } 
        if(!value.isPressed)
        {
            isJumping = false;
        }
    }

    public void Update()
    // Applies additional gravity to the player when jumping or falling to create a more responsive jump feel
    {
        if (isJumping == false && rb.linearVelocity.y > 0) {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    if(rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    // Checks if the player is grounded by casting a ray downwards from the ground position and checking for collisions with the ground layer
    public bool isGrounded()
    {
        RaycastHit2D grounded = Physics2D.Raycast(ground.position, Vector2.down, .2f, groundlayer);

        // If the raycast hits a collider, the player is grounded and the function returns true. Otherwise, it returns false.
        if (grounded.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    public void TakeDamage(int damage)
    {
        if(isInvincible)
        {
            return;
        }
        health -= damage;
        isInvincible = true;
        healthui.UpdateHealth(health);
        if (health <= 0)
        {
            Die();
            StartCoroutine(RespawnDelay());
        } else
        {
            StartCoroutine(InvincibilityFrames());
        }


        
    }

    IEnumerator InvincibilityFrames()
    {
    
        yield return new WaitForSeconds(1f);
        isInvincible = false;
        Debug.Log("IFrame off");
    }

    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(1f);
        Respawn();
    }

    public void setCheckPoint(Vector2 position) 
    {
        respawnpoint = position;
    }

    public Vector2 getCheckPoint()
    {
        return respawnpoint;
    }


    public void Die() 
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        playerInput.DeactivateInput();
        Debug.Log("Player Died");


    }

    public void Respawn() 
    {
        isDead = false;
        transform.position = respawnpoint;
        health = 5;
        healthui.UpdateHealth(health);
        playerInput.ActivateInput();
        Debug.Log("Player Respawned");
    }
}
