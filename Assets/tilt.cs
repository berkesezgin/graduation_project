using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour
{

    public Vector3 currenRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currenRot = GetComponent<Transform>().eulerAngles;

        if ((Input.GetAxis("Horizontal") > .2) && (currenRot.z <= 10 || currenRot.z >=348 ))
        {
            transform.Rotate(0, 0, 0.7f);
        }

        if ((Input.GetAxis("Horizontal") < -.2) && (currenRot.z >= 349 || currenRot.z <= 11))
        {
            transform.Rotate(0, 0, -0.7f);
        }

        if ((Input.GetAxis("Vertical") > .2) && (currenRot.x <= 10 || currenRot.x >= 348))
        {
            transform.Rotate(0.7f, 0, 0);
        }

        if ((Input.GetAxis("Vertical") < -.2) && (currenRot.x >= 349 || currenRot.x <= 11))
        {
            transform.Rotate(-0.7f, 0, 0);
        }
    }
}
