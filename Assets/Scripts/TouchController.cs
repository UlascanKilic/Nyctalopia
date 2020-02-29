using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    Touch touch;
    public float forwardForce = 2f;
    public float speed = 0.01f;

    public bool isGameOver = false;

    int screenHeightHalf, screenWidthHalf;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            screenHeightHalf = Screen.currentResolution.height / 2;
            screenWidthHalf = Screen.currentResolution.width / 2;
        }
        speed = 0.01f;
    }


    void Update()
    {
        if (!isGameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardForce);

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
                }
            }
            if (transform.position.x <= -1)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= 1)
            {
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            }
        }
  
    }
}
