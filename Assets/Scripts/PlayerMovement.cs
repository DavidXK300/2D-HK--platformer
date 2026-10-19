using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

   


    Vector2 movementInput;
    private float movementSpeed = 5f;
    Rigidbody2D rb;
    bool jumpPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        rb.linearVelocity = new Vector2(movementInput.x * (movementSpeed * 0.09f), rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        Debug.Log(movementInput);


    }
}
