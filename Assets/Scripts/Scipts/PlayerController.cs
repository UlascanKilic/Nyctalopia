using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float forwardForce = 5f;
    public bool collision = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")) // Sola git
        {
            transform.Translate(Vector3.left * Time.deltaTime * forwardForce);
            Debug.LogError("sol");
        }
        if (Input.GetKeyDown("d")) // Sağa git
        {
            transform.Translate(Vector3.right * Time.deltaTime * forwardForce);
            Debug.LogError("sağ");
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if(touch.position.x < Screen.width / 2 )
                {
                    transform.position = new Vector3(transform.position.x - 1.75f, transform.position.y);
                    Debug.LogError("sol");
                }
                if(touch.position.x > Screen.width / 2 )
                {
                    transform.position = new Vector3(transform.position.x + 1.75f, transform.position.y);
                    Debug.LogError("sağ");
                }
            }
        }
       
    }
    private void OnTriggerEnter()
    {
        collision = true;
    }
}
