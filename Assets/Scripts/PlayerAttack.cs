using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform AttackPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttack(InputValue value)
    {
        // Implement attack logic here
        if(value.isPressed)
        {
            Debug.Log("Attack!");

            Collider2D attacked = Physics2D.OverlapCircle(AttackPoint.position, 2f, LayerMask.GetMask("Enemy"));
            if (attacked != null)
            {
                attacked.gameObject.GetComponent<Enemies>().TakeDamage(5);
                Debug.Log("hitsomething");
            } 

        }
    }
}
