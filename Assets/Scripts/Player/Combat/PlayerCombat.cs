using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsEnemies;

    public int attackDamage = 10;
    public float startTimeBtwnBasicAttack;  // Delay between basic attacks
    public float attackRange;

    private float timeBtwnBasicAttack;
    private int attackCounter;

    private PlayerCombatAnimationContoller animator;
    //private ScoreManager scoreManager;
    private ParallelMovement characterMovement;

    private void Awake()
    {
        animator = GetComponent<PlayerCombatAnimationContoller>();
        characterMovement = GetComponent<ParallelMovement>();
        //scoreManager = GameObject.FindGameObjectWithTag("Data").GetComponent<ScoreManager>();
    }
    private void Start()
    {
        //basicAttackDamage = scoreManager.data.dataAttackDamage; // setting a character attack damage from data
        //strikeDamage = scoreManager.data.dataStrikeDamage;
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (timeBtwnBasicAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                CheckAttackCount();
                StopCharacterWhenAttack();
                //MusicManager.PlaySound("Sword");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().EnemyTakeDamage(attackDamage);
                }

                timeBtwnBasicAttack = startTimeBtwnBasicAttack;
            }
        }
        else
        {
            timeBtwnBasicAttack -= Time.deltaTime;
        }
    }


    private void CheckAttackCount()
    {
        attackCounter++;

        if (attackCounter == 1)
        {
            animator.PlayAttackAnim();
        }
        else if (attackCounter == 2)
        {
            animator.PlayAttack2Anim();
        }
        else
        {
            animator.PlayAttack3Anim();

            attackCounter = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void StopCharacterWhenAttack()
    {
        characterMovement.movementSpeed = 0f;
        Invoke("GiveBackMovementSpeed", 0.55f);
    }
    public void GiveBackMovementSpeed()
    {
        characterMovement.movementSpeed = 5f;
    }
}
