using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] environments;
    public GameObject[] backGrounds;
    public GameObject[] hearts;
    public Color[] colors;

    public CameraControl camControl;
    public PlayerHealth health;
    public TrapDamage trap;

    private bool parallel = false;

    
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {

            CheckForParallel();
            
            if (parallel == true)
            {                
                
                players[0].SetActive(false);
                players[1].SetActive(true);

                for (int i = 0; i < environments.Length; i++)
                {
                    environments[i].GetComponent<Rigidbody2D>().isKinematic = true;
                    
                    environments[i].GetComponent<SpriteRenderer>().color = colors[1];
                }
                backGrounds[0].SetActive(false);
                backGrounds[1].SetActive(true);

                hearts[0].SetActive(false);
                hearts[1].SetActive(true);

            }
            else if (parallel == false)
            {
                players[0].SetActive(true);
                players[1].SetActive(false);

                for (int i = 0; i < environments.Length; i++)
                {
                    environments[i].GetComponent<Rigidbody2D>().isKinematic = false;
                    environments[i].GetComponent<SpriteRenderer>().color = colors[0];
                }

                backGrounds[0].SetActive(true);
                backGrounds[1].SetActive(false);

                hearts[0].SetActive(true);
                hearts[1].SetActive(false);

            }
            camControl.TurnCameraToPlayer();
            health.UpdatePlayerHealthText();
            trap.FindPlayerTag();
        }
    }

    private void CheckForParallel()
    {
        if (parallel == false)
        {
            parallel = true;
        }
        else
        {
            parallel = false;
        }
    }
}
