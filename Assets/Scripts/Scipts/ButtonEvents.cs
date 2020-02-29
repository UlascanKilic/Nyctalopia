using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{


    AudioManager manager;
    GameController controller;
    string sceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MENU_StartGame()
    {
        manager.Play("Meow");
        sceneName = "Level1";
        Invoke("CallDelayedScene", 1f);
        //load first level
    }
    public void MENU_Achievements()
    {
        manager.Play("UIPress");
        //load first level
    }
    public void MENU_Skins()
    {
        manager.Play("UIPress");
        //load first level
    }
    public void MENU_Settings()
    {
        manager.Play("UIPress");
        //load first level
    }

    public void CallScene(string name)
    {
        sceneName = name;
        Invoke("CallDelayScene", 0.65f);
        //SceneManager.LoadScene(name);
    }

    void CallDelayedScene()
    {
        SceneManager.LoadScene(sceneName);
        manager.StopAllMusic();
    }


    public void ToggleVibration()
    {
        controller.ToggleVibration();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
