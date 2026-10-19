using UnityEngine;



public class CheckPoint : MonoBehaviour
{
    public Player2 player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Checkpoint reached!");
            player = other.gameObject.GetComponent<Player2>();
            player.setCheckPoint(transform.position);
            Debug.Log("New Spawn Point: " + player.getCheckPoint());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
