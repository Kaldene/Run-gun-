using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 30f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
