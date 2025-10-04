using System;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    private float horizontalInput;
    private PlayerCore core;
    private bool isFacingRight = true;
    private bool walking;

    private void Start()
    {
        core = PlayerCore.Instance;
    }

    private void Update()
    {
        if (core == null) return;
        walking = isWalking();
        Walk();
        HandleFlip();
    }

    private void Walk()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        core.rb.linearVelocity = new Vector2(horizontalInput * _speed, core.rb.linearVelocity.y);
        core.animator.SetBool("run", walking);
    }

    private void HandleFlip()
    {
        if(horizontalInput == 0) return;
        
        bool shouldFlip = horizontalInput > 0;
        if (shouldFlip != isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * (isFacingRight ? 1 : -1);
        transform.localScale = newScale;
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }
    public bool isWalking()
    {
        return Mathf.Abs(horizontalInput) > Mathf.Epsilon;
        
    }
}