using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    public static Rigidbody2D rb;
    public static float moveSpeed;
    public static float moveSmoothTime;

    private float InputX;

    private static Vector2 currentVelocity;

    public MoveCommand(float inputX)
    {
        this.InputX = inputX;
    }

    public static void SetUp(Rigidbody2D _rb, float _moveSpeed, float _moveSmoothTime)
    {
        rb = _rb;
        moveSpeed = _moveSpeed;
        moveSmoothTime = _moveSmoothTime;
    }

    public void Execute()
    {
        Vector2 targetVelocity = new Vector2(InputX * moveSpeed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, moveSmoothTime);
    }
}
