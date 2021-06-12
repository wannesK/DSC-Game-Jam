using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;
    public GameObject bloodEffect;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void EnemyTakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("enemyHurt");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        SoundManager.PlaySound("SwordImpact");

        if (health < 1)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<EnemyAI>().enabled = false;
            anim.SetTrigger("enemyDead");
            Destroy(gameObject, 0.8f);
        }
    }
}
