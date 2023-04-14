using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Transform feet;

    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    float jumpForce;

    int groundLayer;
    bool jumpKeyPressed;
    
    public bool Jumping { get; private set; }
    
    public void OnStart()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
    }
    
    public void CheckJump()
    {
        var ground = IsGround();
        var canJump = ground;
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            jumpKeyPressed = true;
        }

        if (!canJump)
        {
            jumpKeyPressed = false;
        }

        Jumping = !canJump;
    }

    public void Jump()
    {
        if (jumpKeyPressed)
        {
            rb.AddForce(Time.fixedDeltaTime * jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }

    bool IsGround()
    {
        bool ground = Physics2D.OverlapCircle(feet.position, groundCheckRadius, groundLayer);

        return ground;
    }
}
