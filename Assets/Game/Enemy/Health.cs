using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float health;
    public float currentHealth;

    private Animator anim;
    private bool _depleted;

    public UnityEvent OnHealthDepletion;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
    }

    void Update()
    {
        if (_depleted) return;
        
        if (health < currentHealth)
        {
            currentHealth = health;
        }

        if (health <= 0)
        {
            _depleted = true;
            anim.SetBool("isTagged", true);
            OnHealthDepletion.Invoke();
        }
    }
}