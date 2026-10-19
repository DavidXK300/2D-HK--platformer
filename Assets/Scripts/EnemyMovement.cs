using JetBrains.Annotations;
using UnityEngine;



public class EnemyMovement : MonoBehaviour
{
    public int direction = 1;
    public Transform enemy;
    public Rigidbody2D rb;
    public float speed;
    public float pointA;
    public float pointB;
    public LayerMask groundlayer;
    public Transform ground;
    public Transform walls;

    public Transform player;
    float enemySpeed;
    float startingPoint;
    public float chaseRange;

    public bool isChasing;

    enum EnemyState
    {
        Patrol,
        Chase,
        Blocked
    }

    EnemyState currentState = EnemyState.Patrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPoint = enemy.position.x;
        pointA = startingPoint + 8f;
        pointB = startingPoint - 8f;

    }


    private void FixedUpdate()
    {
        enemySpeed = speed * direction;


        if (EnemyState.Blocked == currentState)
        {
            enemySpeed = 0;
        }

        rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocity.y);


    }

    // Update is called once per frame
    void Update()
    {
        Collider2D pAttacked = Physics2D.OverlapCircle(enemy.position, chaseRange, LayerMask.GetMask("Player"));



        if (pAttacked != null)
        {
            Debug.Log("Player Detected");
            if (isWall() == false)
            {
                currentState = EnemyState.Chase;
            }
            else
            {
                currentState = EnemyState.Blocked;
            }
        }




        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();

                isChasing = false;
                if (isGrounded() == false || isWall() == true)
                {
                    TurnAround();
                }
                break;
            case EnemyState.Chase:
                ChasePlayer();
                isChasing = true;
                break;
        }





    }
    void ChasePlayer()
    {
        Collider2D pAttacked = Physics2D.OverlapCircle(enemy.position, chaseRange, LayerMask.GetMask("Player"));

        if (player.position.x < enemy.position.x)
        {
            direction = -1;

        }
        else if (player.position.x > enemy.position.x)
        {
            direction = 1;

        }

    }
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
    void Patrol()
    {
        if (enemy.position.x >= pointA)
        {
            direction = -1;

        }
        else if (enemy.position.x <= pointB)
        {
            direction = 1;

        }
    }

    void TurnAround()
    {
        direction *= -1;
        Vector3 groundPosition = ground.localPosition;  // get
        groundPosition.x *= -1;                         // modify
        ground.localPosition = groundPosition;
    }

    public bool isWall()
    {
        RaycastHit2D wall = Physics2D.Raycast(walls.position, Vector2.right * direction, .2f, groundlayer);

        if (wall.collider != null)
        {
            Debug.Log("Wall Detected");
            return true;

        }
        else
        {
            return false;
        }
    }


}
