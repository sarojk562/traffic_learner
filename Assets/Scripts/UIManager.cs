using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject MenuCanvas, SettingCanvas, pauseCanvas;

    private void Awake()
    {
        SettingCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void loadInfo()
    {
        SceneManager.LoadScene("Info");
    }

    public void loadQuiz()
    {
        SceneManager.LoadScene("Game");
    }

    public void loadSettings()
    {
        SettingCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void goBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void backFromSettings()
    {
        MenuCanvas.SetActive(true);
        SettingCanvas.SetActive(false);
    }

    public void StartCarGame()
    {
        SceneManager.LoadScene("level1");
    }

    public static void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
