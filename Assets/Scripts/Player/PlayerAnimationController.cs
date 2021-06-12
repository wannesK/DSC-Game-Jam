using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;

    private float delay = 1f;
    private float count;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (count <= delay)
        {
            count += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S) && count >= delay)
        {            
            anim.SetTrigger("Crouch");
            count = 0;
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
