using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {            
            anim.SetTrigger("Crouch");
        }
    }
    public void PlayRunningAnim()
    {
        anim.SetBool("Running", true);
        anim.SetBool("Jumping", false);
    }
    public void PlayJumpingAnim()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", true);
    }
    public void PlayIdleAnim()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Jumping", false);
    }
}
