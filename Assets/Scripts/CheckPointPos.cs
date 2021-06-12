using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPos : MonoBehaviour
{
    private CheckPointManager checkPointManager;
    private void Start()
    {
        checkPointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointManager.lastCheckPointPos = transform.position;
        }
    }
}
