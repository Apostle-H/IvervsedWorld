using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    [SerializeField] private Transform healthHoloder;
    [SerializeField] private Sprite hasSprite;
    [SerializeField] private Sprite lostSprite;

    [SerializeField] private GameObject DieMenu;

    private int health = 3;

    private void Awake()
    {
        for (int i = 0; i < healthHoloder.childCount; i++)
        {
            healthHoloder.GetChild(i).GetComponent<Image>().sprite = hasSprite;
        }
    }

    public void TakeDamage()
    {
        health -= 1;

        healthHoloder.GetChild(health).GetComponent<Image>().sprite = lostSprite;
        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        inputHandler.dead = true;
    }
}
