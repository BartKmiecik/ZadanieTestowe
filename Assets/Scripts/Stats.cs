using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            --currentHealth;
            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
