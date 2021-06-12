using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public GameObject levelEndPanel;
    public GameObject infoPanel;

    public int playerCounter;
    public bool p1, p2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && p1 == false)
        {
            playerCounter++;
            p1 = true;
            infoPanel.SetActive(true);
        }
        else if (other.gameObject.name == "PlayerSword" && p2 == false)
        {
            playerCounter++;
            p2 = true;
            infoPanel.SetActive(true);
        }
        if (p1 == true && p2 == true)   
        {
            infoPanel.SetActive(false);
            Invoke("EndLevel", 1.1f);
        }
    }
    private void EndLevel()
    {
        levelEndPanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
