using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZone : MonoBehaviour
{
    private PlayerHealth player;
    private EnemyAI enemyParent;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyAI>();
        anim = GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            enemyParent.Flip();
        }

        if (player.playerHealth < 1)
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();

        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        inRange = false;
        gameObject.SetActive(false);
        enemyParent.triggerArea.SetActive(true);
        enemyParent.inRange = false;
        enemyParent.SelectTarget();
    }
}
