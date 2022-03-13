using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsChecker : MonoBehaviour
{
    [SerializeField] private string rotateTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(rotateTag))
        {
            CommandInvoker.AddCommand(new TakeDamageCommand());
            CommandInvoker.AddCommand(new RotateWorldCommand());
        }
    }
}
