using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject MenuCanvas, SettingCanvas, pauseCanvas;

    public void StartCarGame()
    {
        SceneManager.LoadScene("level1");
    }

    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
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
        SceneManager.LoadScene("Quiz");
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
        //SettingCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
