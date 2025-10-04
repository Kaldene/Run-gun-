using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private LayerMask whatIsObstacle;

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Vector2 direction;
    private Rigidbody2D rb;

    public void Initialize(Vector2 dir, float spd, float dmg)
    {
        direction = dir;
        speed = spd;
        damage = dmg;
        rb = GetComponent<Rigidbody2D>();

        if (dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Destroy(gameObject, lifetime);
    }
    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsEnemy) != 0)
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (((1 << collision.gameObject.layer) & whatIsObstacle) != 0)
        {
            Destroy(gameObject);
        }
    }
}
