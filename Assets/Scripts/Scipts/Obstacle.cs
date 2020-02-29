using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ObstacleType
{
    Human,
    Bicycle,
    Dog,
    Tree,
    Mouse
}
public class Obstacle : MonoBehaviour
{

    public bool hasPlayedBefore = false;
    AudioSource source;
    public AudioClip clip;
    public ObstacleType Type;
    GameObject player;

    GameController controller;

    public float playDistance = 8f, maxValueDistance = 3f;

    public AnimationCurve applyCurve;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        //source = GameObject.FindGameObjectWithTag("GlobalAudioSource").GetComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
        source.clip = clip;
        //source.gameObject.transform.position = GameObject.FindGameObjectWithTag("GlobalAudioSource").transform.position;
        source.gameObject.transform.position = transform.position;
        source.loop = true;

        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.z - player.transform.position.z) <= playDistance)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
            source.panStereo = transform.position.x - player.transform.position.x;
            if (Mathf.Abs(transform.position.z - player.transform.position.z) <= maxValueDistance)
            {
                source.volume = 1;
            }
            else
            {
                source.volume = applyCurve.Evaluate(transform.position.z - player.transform.position.z);
            }
            //PlaySound();
        }else{
            source.loop = false;
        }

    }

    public void PlaySound()
    {
        if (!hasPlayedBefore)
        {
            //play
            hasPlayedBefore = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("game over");
            GameObject.FindGameObjectWithTag("Player").GetComponent<TouchController>().isGameOver = true;
            //game over canvas is enabled
            //GameObject.FindGameObjectWithTag("GameOverPanel").GetComponent<Canvas>().enabled = true;
            controller.ShowGameOverUI();
            //Time.timeScale = 0f;
          
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
