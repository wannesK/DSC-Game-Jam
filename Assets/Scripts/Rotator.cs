using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, rotateSpeed * Time.deltaTime);
    }
}
