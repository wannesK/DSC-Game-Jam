using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private PlayerHealth health;
    private bool canTakeDamage = true;
    private void Start()
    {
        FindPlayerTag();
    }

    private void Update()
    {        
        if (canTakeDamage == false)
        {
            Invoke("CanTakeDamage", 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTakeDamage == true)
        {
            health.DecreasePlayerHealth();
            canTakeDamage = false;
        }
    }
    
    public void FindPlayerTag()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void CanTakeDamage()
    {
        canTakeDamage = true;
    }
}
