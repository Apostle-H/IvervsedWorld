using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MoveSmoothTime;

    [SerializeField] private float JumpForce;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private HealthManager healthManager;
    private static Shader forWhiteShader;
    private static Shader normalShader;

    [SerializeField] private Transform level;

    public static Queue<ICommand> commands = new Queue<ICommand>();

    public static void AddCommand(ICommand command)
    {
        commands.Enqueue(command);
    }

    private void Awake()
    {
        MoveCommand.SetUp(rb, MoveSpeed, MoveSmoothTime);
        JumpCommand.SetUp(rb, JumpForce);
        TakeDamageCommand.SetUp(this, healthManager);
        RotateWorldCommand.SetUp(level, rb.transform);

        forWhiteShader = Shader.Find("GUI/Text Shader");
        normalShader = Shader.Find("Sprites/Default");
    }

    private void FixedUpdate()
    {
        while (commands.Count > 0)
        {
            commands.Dequeue().Execute();
        }
    }

    public void TakeDamage()
    {
        StartCoroutine("GoWhite");
    }

    private IEnumerator GoWhite()
    {
        spriteRenderer.material.shader = forWhiteShader;
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.material.shader = normalShader;
        spriteRenderer.color = Color.white;
    }
}
