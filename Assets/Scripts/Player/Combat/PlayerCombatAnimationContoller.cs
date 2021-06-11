using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatAnimationContoller : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void PlayIdleAnim()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", false);
    }
    public void PlayAttackAnim()
    {
        anim.SetTrigger("Attack");
    }
    public void PlayAttack2Anim()
    {
        anim.SetTrigger("Attack2");
    }
    public void PlayAttack3Anim()
    {
        anim.SetTrigger("Attack3");
    }
    public void PlayJumpingAnim()
    {
        anim.SetBool("Jumping", true);
        anim.SetBool("Running", false);

    }
    public void PlayRunningAnim()
    {
        anim.SetBool("Running", true);
        anim.SetBool("Jumping", false);
    }
    public void PlayHurtAnim()
    {
        anim.SetTrigger("Hurt");

    }
}
