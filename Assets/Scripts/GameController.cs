using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    GameObject canvas;
    RectTransform GameOverPanel, LevelEndPanel;
    public bool isVibrationOn = false;
    AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            manager.PlayMusic("Menu");
        }
        else
        {
            canvas = GameObject.FindGameObjectWithTag("Canvas").gameObject;
            GameOverPanel = canvas.transform.Find("GameOverPanel").GetComponent<RectTransform>();
            LevelEndPanel = canvas.transform.Find("LevelEnd").GetComponent<RectTransform>();
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleVibration()
    {
        isVibrationOn = !isVibrationOn;
    }

    public void ShowGameOverUI()
    {
        GameOverPanel.gameObject.SetActive(true);
    }
    public void ShowLevelEndUI()
    {
        LevelEndPanel.gameObject.SetActive(true);
    }
    public void HideGameOverUI()
    {
        GameOverPanel.gameObject.SetActive(false);
    }
    public void HideLevelEndUI()
    {
        LevelEndPanel.gameObject.SetActive(false);
    }
}
