using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;


    private void Start()
    {
        GetComponent<Camera>().orthographicSize = 2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTransform != null)
        {
            this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        }

    }
}
