using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Settings jump")]
    [SerializeField] private float jumpForce = 10f;
    private bool isJumping;

    [Header("Settings animation jump")] 
    private float timer;
    private float jumpTimer = 0.2f;
    
    
    [Header("Imported components")]
    private PlayerCore core;
    private PlayerChekGround chekGround;
    private PlayerMovment movment;

    private void Awake()
    {
        core = PlayerCore.Instance;
        chekGround = GetComponent<PlayerChekGround>();
        movment = GetComponent<PlayerMovment>();
    }

    private void Update()
    {
        if (core == null) return;
        Jump();
        UpdeteAnimation();
        HandleFall();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && chekGround.asGrounded)
        {
            core.animator.SetTrigger("Jump");
            isJumping = true;
            LogicJump();
        }
        isJumping = false;
    }

    private void LogicJump()
    {
        core.rb.linearVelocity = new Vector2(core.rb.linearVelocity.x, 0);
        core.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void UpdeteAnimation()
    {
        core.animator.SetBool("Walking", movment.isWalking());
        core.animator.SetBool("isGruond", chekGround.IsGrounded()); 
    }
    private void HandleFall()
    {
        if (core.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && core.rb.linearVelocity.y < 0)
        {
            core.animator.SetBool("isFalling", true);
        }
    
        if (chekGround.asGrounded)
        {
            core.animator.SetBool("isFalling", false);
        }
    }
} 
        
    
