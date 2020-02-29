using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObstacle : MonoBehaviour
{
    [HideInInspector]
    GameObject currentObstacle;
    ObstacleType Type;
    AudioSource source;
    public AudioClip human, bicycle, dog, mouse, car, tree;
    AudioClip clip;
    public AnimationCurve applyCurve;
    //public float panAmount = 0f;
    bool isChecked = false;

    public float panDistance = 3f, playDistance = 2f, maxValueDistance = 1.5f;
    // float distanceX = 0f, distanceZ = 0f;

    void Start()
    {
        source = GameObject.FindGameObjectWithTag("GlobalAudioSource").GetComponent<AudioSource>();
    }

    void Update()
    {
        try
        {
            if (Mathf.Abs(currentObstacle.transform.position.z - transform.parent.position.z) <= playDistance)
            {
                currentObstacle.GetComponent<Obstacle>().PlaySound();
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    GameObject temporary;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //temporary = 
            // source = gameObject.AddComponent<AudioSource>();
            currentObstacle = collision.gameObject;

            Type = collision.GetComponent<Obstacle>().Type;
            switch (Type)
            {
                case ObstacleType.Bicycle:
                    clip = bicycle;
                    break;
                case ObstacleType.Dog:
                    clip = dog;
                    break;
                case ObstacleType.Human:
                    clip = human;
                    break;
                case ObstacleType.Mouse:
                    clip = mouse;
                    break;
                case ObstacleType.Tree:
                    clip = tree;
                    break;
            }
            source.clip = clip;

        }
    }
    // void OnTriggerExit(Collider collsion){
    //     if(collsion.CompareTag("Obstacle")){
    //         isChecked = false;
    //     }
    // }
}
