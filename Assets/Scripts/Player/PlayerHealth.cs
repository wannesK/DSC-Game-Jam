using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 2;

    public GameObject[] hearts;
    public TextMeshProUGUI healtText;

    public Animator anim;
    public PlayerMovement movement;
    public ParallelMovement movementP;
    public GameManager manager;
    public CameraControl cam;

    public GameObject deadScreen;
    public GameObject deadEffect;

    private Rigidbody2D rigid;
    private CheckPointManager pointManager;
    private void Awake()
    {
        Time.timeScale = 1f;
        pointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        transform.position = pointManager.lastCheckPointPos;

        UpdatePlayerHealthText();
        CheckHearts();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitBox"))
        {
            DecreasePlayerHealth();
        }
        else if (other.CompareTag("Water"))
        {
            rigid.velocity = Vector2.up * 13;
            DecreasePlayerHealth();
        }
    }
    public void DecreasePlayerHealth()
    {
        playerHealth--;
        anim.SetTrigger("Hurt");

        CheckHearts();
        UpdatePlayerHealthText();

        if (playerHealth < 1)
        {

            movement.GetComponent<PlayerMovement>().enabled = false;
            movementP.GetComponent<ParallelMovement>().enabled = false;
            manager.GetComponent<GameManager>().enabled = false;
            cam.GetComponent<CameraControl>().enabled = false;

            rigid.velocity = new Vector2(0, rigid.velocity.y);

            Time.timeScale = 0.6f;

            anim.SetTrigger("Dead");
            Invoke("SetActiveDeadScreen", 0.8f);
            DestroyPlayer();

        }
    }
    public void UpdatePlayerHealthText()
    {
        healtText.text = "Health : " + playerHealth;
    }
    private void DestroyPlayer()
    {
        //Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(movement.gameObject, 0.9f);
        Destroy(movementP.gameObject, 0.9f);
    }
    private void SetActiveDeadScreen()
    {
        deadScreen.SetActive(true);
    }

    private void CheckHearts()
    {
        if (playerHealth == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
        }
        else if (playerHealth == 1)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
        }
        else if (playerHealth == 0)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
        }
    }
}
