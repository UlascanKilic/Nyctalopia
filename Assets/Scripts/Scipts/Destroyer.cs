using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destroyer : MonoBehaviour
{
    Button SkillButton;
    Color color;
    Image image;
    GameObject Object;
    // Start is called before the first frame update

    void Start()
    {
        SkillButton = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InGamePanel").transform.Find("SkillBar").GetComponent<Button>();
        image = SkillButton.GetComponent<Image>();
        color = image.color;
    }

    public int destroyedAmount = 0;
    private void OnTriggerEnter(Collider other)
    {
        destroyedAmount++;
        color.a = 256 * (destroyedAmount / 8);
        if (destroyedAmount > 8)
        {
            //Play new skill here
            //Button available.
        }
        else
        {

        }
        if (other.gameObject.tag == "Build")
        {
            Object = other.gameObject;
            Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 35f);
            // Invoke("DelayedMover",2.5f);
        }
        else
        {
            Destroy(other.gameObject);
        }


    }
    void DelayedMover()
    {
        Object.transform.position = new Vector3(Object.transform.position.x, Object.transform.position.y, Object.transform.position.z + 35f);
    }

}
