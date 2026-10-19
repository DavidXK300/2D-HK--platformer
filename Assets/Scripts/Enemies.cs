using Unity.Burst.CompilerServices;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        } 
    }
     // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage dealth by" + gameObject.name);

            collision.gameObject.GetComponent<Player2>().TakeDamage(1);
        }
    }
   
}
