using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gamePausedText;
    public GameObject noOptionsYet;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        gamePausedText.SetActive(false);
        noOptionsYet.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }  
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePausedText.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gamePausedText.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadOptions()
    {
        noOptionsYet.SetActive(true);
        Debug.Log("Loading Options");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
