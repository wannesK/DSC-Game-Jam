using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContoller : MonoBehaviour
{
    public float delay = 4f;

    private float counter;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= delay)
        {
            VoodTrapTrigger();
            counter = 0;

            Invoke("test", 1f);
        }
        
    }

    private void VoodTrapTrigger()
    {
        anim.SetBool("TrapTriggered", true);
    }
    private void test()
    {
        anim.SetBool("TrapTriggered", false);
    }
}
