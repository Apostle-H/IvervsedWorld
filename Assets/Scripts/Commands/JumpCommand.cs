using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private static Rigidbody2D rb;
    private static float jumpForce;


    public static void SetUp(Rigidbody2D _rb, float _jumpForce)
    {
        rb = _rb;
        jumpForce = _jumpForce;
    }

    public void Execute()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
