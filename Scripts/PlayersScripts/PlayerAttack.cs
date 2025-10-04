using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float damage;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown;
    private float lastAttackTime;

    private PlayerCore core;
    private PlayerMovment movement;

    private void Awake()
    {
        core = PlayerCore.Instance;
        movement = GetComponent<PlayerMovment>();
    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButton(0) && Time.time - lastAttackTime >= attackCooldown)
        {
            CreateProjectile();
            lastAttackTime = Time.time;
        }
    }

    private void CreateProjectile()
    {
        if (projectilePrefab != null && attackPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
            Vector2 direction = movement.IsFacingRight() ? Vector2.right : Vector2.left;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
    
            if (rb != null)
                rb.linearVelocity = direction * speed;

            Destroy(projectile, 2f);
        }
    }
}