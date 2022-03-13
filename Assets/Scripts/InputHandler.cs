using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;

    [SerializeField] private Transform Feet;
    [SerializeField] private float GroundCheckRadius;
    [SerializeField] private LayerMask GroundLayer;

    [SerializeField] private float inputXSensivity;

    public bool dead;

    private PlayerInputActions playerInputActions;
    private float inputX;
    private float inputXIncreaseT;

    private bool standUp;

    private bool facingRigth;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Simple.Enable();

        playerInputActions.Simple.Jump.started += Jump;
        playerInputActions.Simple.Movement.started += MovementStarted;
        playerInputActions.Simple.Movement.canceled += MovementCanceled;
    }

    private void MovementStarted(InputAction.CallbackContext context)
    {
        if (!dead)
        {
            inputXIncreaseT = 0;
            animator.SetBool("Move", true);
        }
    }

    private void MovementCanceled(InputAction.CallbackContext context)
    {
        if (!dead)
        {
            animator.SetBool("Move", false);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (Physics2D.OverlapCircle(Feet.position, GroundCheckRadius, GroundLayer) && !standUp && !dead)
        {
            animator.SetTrigger("Jump");
            CommandInvoker.AddCommand(new JumpCommand());
        }
    }

    private void Update()
    {
        if ((!facingRigth && playerInputActions.Simple.Movement.ReadValue<float>() > 0 || facingRigth && playerInputActions.Simple.Movement.ReadValue<float>() < 0) && !standUp && !dead)
        {
            Flip();
        }

        if (!standUp && !dead)
        {
            CommandInvoker.AddCommand(new MoveCommand(SmoothInput()));
        }
        else
        {
            CommandInvoker.AddCommand(new MoveCommand(0));
        }

        if (rb.velocity.y <= -10f)
        {
            animator.SetBool("Fall", true);
        }

        if (dead)
        {
            animator.SetBool("Dead", true);
        }

        animator.SetBool("GoDown", rb.velocity.y < -.1);
        animator.SetBool("Grounded", Physics2D.OverlapCircle(Feet.position, GroundCheckRadius, GroundLayer));
    }

    private float SmoothInput()
    {
        inputX = playerInputActions.Simple.Movement.ReadValue<float>();

        if (inputX == 0 && inputXIncreaseT > 0)
        {
            inputXIncreaseT -= 0.05f * inputXSensivity * Time.deltaTime;
        }
        else if (inputX != 0 && inputXIncreaseT < 1)
        {
            inputXIncreaseT += 0.05f * inputXSensivity * Time.deltaTime;
        }

        inputX = Mathf.Lerp(0, inputX, inputXIncreaseT);

        return inputX;
    }
    
    public void Flip()
    {
        facingRigth = !facingRigth;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        Vector3 healtBarScale = transform.GetChild(1).localScale;
        transform.GetChild(1).localScale = new Vector3(healtBarScale.x * -1, healtBarScale.y, healtBarScale.z); ;
    }

    public void StartStandUp()
    {
        standUp = true;
        animator.SetBool("Fall", false);
    }

    public void EndStandUp()
    {
        standUp = false;
    }
}
