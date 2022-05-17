using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplatform : MonoBehaviour
{
    public Transform toFollow;
    private Vector3 offset;

    void Start()
    {
        offset = toFollow.position - transform.position;
    }
    void FixedUpdate()
    {
        transform.position = toFollow.position - offset;
        transform.rotation = toFollow.rotation;
    }
   
}
