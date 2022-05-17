using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("diff") == 1)
        {

            rb.AddForce(Physics.gravity * rb.mass*100);
            Debug.Log("Made harder");
        }
        if (PlayerPrefs.GetInt("diff") == 0)
        {

            Debug.Log("Made easier");
        }

    }
}
