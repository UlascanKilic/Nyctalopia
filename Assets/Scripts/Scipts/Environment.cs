using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Environment : MonoBehaviour
{
    float randomization = 0f;
    public AudioClip[] clips;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.loop = false;
        string sceneName = SceneManager.GetActiveScene().name;
        switch (name)
        {
            case "Level1":
                randomization = .25f;
                break;
            case "Level2":
                randomization = .5f;
                break;
            case "Level3":
                randomization = .75f;
                break;
            case "Level4":
                randomization = 80f;
                break;

            default: randomization = 0f; break;
        }

    }

    public AudioClip GetRandomSound(){
        return clips[Random.Range(0,clips.Length)];
    }
    public void Play()
    {
        if (Random.Range(0f, 1f) >= randomization)
        {
            source.PlayOneShot(GetRandomSound());
            
        }
        print(randomization);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
