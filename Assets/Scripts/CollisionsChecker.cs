using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsChecker : MonoBehaviour
{
    [SerializeField] private string rotateTag;
    [SerializeField] private string finishTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(rotateTag))
        {
            CommandInvoker.AddCommand(new TakeDamageCommand());
            CommandInvoker.AddCommand(new RotateWorldCommand());
        }

        if (collision.CompareTag(finishTag))
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene((nextLevel > SceneManager.sceneCount) ? 0 : nextLevel);
        }
    }
}
