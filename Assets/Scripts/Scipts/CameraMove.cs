using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerObj;
    Vector3 cameraOffset;
    public float offsetX, offsetY, offsetZ;
    void Start()
    {
        playerObj = GameObject.Find("Player");
        cameraOffset = new Vector3(offsetX, offsetY, offsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObj.transform.position + cameraOffset;
    }
}
