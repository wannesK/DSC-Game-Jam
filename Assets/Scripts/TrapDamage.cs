using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private PlayerHealth health;
    public GameManager manager;
    private void Start()
    {
        FindPlayerTag();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && manager.parallel == false) 
        {
            other.gameObject.GetComponent<PlayerHealth>().DecreasePlayerHealth();
        }
        else if (other.name == "PlayerSword" && manager.parallel == true) 
        {
            other.gameObject.GetComponent<PlayerHealth>().DecreasePlayerHealth();
        }
    }
    
    public void FindPlayerTag()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
}
