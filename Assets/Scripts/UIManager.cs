using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject MenuCanvas, SettingCanvas;
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
}
