using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    private Delegator delegator;
    private Renderer rend;
    private Color defaultColor;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    public void SetDelegator(Delegator delegator)
    {
        this.delegator = delegator;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            --currentHealth;
            if(rend.material.color != defaultColor)
            {
                delegator.updateUI();
            }
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
