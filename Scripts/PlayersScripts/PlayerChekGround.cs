using System;
using UnityEngine;

public class PlayerChekGround : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public bool asGrounded;
    
    private PlayerCore core;

    private void Start()
    {
        core = PlayerCore.Instance;
    }

    private void Update()
    { 
        if(core == null) return;
        asGrounded = IsGrounded();
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(core.boxCollider.bounds.center,core.boxCollider.size, 0f, Vector2.down, 0.5f, groundLayer);
        return hit.collider != null;
    }
}
