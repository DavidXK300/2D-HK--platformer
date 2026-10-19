using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {

            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        



           
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
        
    }
}
