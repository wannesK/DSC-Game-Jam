using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float followSpeed;
    public float minX, maxX;
    public float minY, maxY;

    private Transform player;
    //private CheckPointManager checkPoint;
    private void Awake()
    {
        //checkPoint = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
    }
    void Start()
    {
        //transform.position = new Vector3(checkPoint.lastCheckPointPos.x, checkPoint.lastCheckPointPos.y, -10);
        TurnCameraToPlayer();
    }
    void LateUpdate()
    {
        Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, nextPos, followSpeed * Time.deltaTime);
    }

    public void TurnCameraToPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
