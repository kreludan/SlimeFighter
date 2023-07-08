using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;


    private void Start()
    {
        Debug.Log(GetComponent<Camera>().orthographicSize);
        GetComponent<Camera>().orthographicSize = 2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        
    }
}
