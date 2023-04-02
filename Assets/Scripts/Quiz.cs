using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Quiz : MonoBehaviour
{
    public GameObject[] AnswerButtons;
    public GameObject retryBtn, nextBtn, ThumbnailUI, QuestionUI;
    public static string[] answers = {"15mph"};
    public Image image;
    public Text question, option1, option2, option3;
    private static int questionScreen;
    public Button[] button;
    public Image oldImage;
    public Sprite[] questionImage;

    public void Incorrect(int j, int k)
    {
        for(int i=0; i<AnswerButtons.Length; i++)
        {
            if (i != j && i != k)
                AnswerButtons[i].SetActive(false);
        }
        retryBtn.SetActive(true);
        nextBtn.SetActive(false);
    }

    public void Correct(int j)
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            if (i != j)
                AnswerButtons[i].SetActive(false);
        }
        retryBtn.SetActive(false);
        nextBtn.SetActive(true);
    }

    public void Retry()
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].SetActive(true);
        }
        retryBtn.SetActive(false);
        nextBtn.SetActive(false);
        ResetColor();
    }

    public void reloadScene()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void ShowQuestions()
    {
        ThumbnailUI.SetActive(false);
        QuestionUI.SetActive(true);
        string questions = EventSystem.current.currentSelectedGameObject.name;
        if(questions == "1")
        {
            oldImage.sprite = questionImage[2];
            question.text = "The speed limit approaching a school crosswalk is ?";
            option1.text = "15mph";
            option2.text = "20mph";
            option3.text = "25mph";
            questionScreen = 1;
            return;
        }

        if (questions == "2")
        {
            oldImage.sprite = questionImage[0];
            question.text = "All arrived at an uncontrolled intersection at the same time. Which has the right-of-way?";
            option1.text = "Car2";
            option2.text = "Car1";
            option3.text = "Car3";
            questionScreen = 2;
            return;
        }

        if (questions == "3")
        {
            oldImage.sprite = questionImage[2];
            question.text = "When no speed limit is posted, the maximum speed in a business or residential area is:";
            option1.text = "30mph";
            option2.text = "25mph";
            option3.text = "35mph";
            questionScreen = 3;
            return;
        }

        if (questions == "4")
        {
            oldImage.sprite = questionImage[1];
            question.text = "The car that made a correct turn was";
            option1.text = "Car2";
            option2.text = "Car1";
            option3.text = "Car3";
            questionScreen = 4;
            return;
        }

    }

    public void checkAnswer()
    {
        if(questionScreen == 1)
        {
            string actual = "15mph";
            string expected = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; 
            if (actual == expected)
            {
                setButtonGreen(button[0]);
                Correct(0);
                return;
            }
            else
            {
                setButtonRed(button[1], button[2]);
                Incorrect(1, 2);
                return;
            }
        }

        if (questionScreen == 2)
        {
            string actual = "Car3";
            string expected = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            if (actual == expected)
            {
                setButtonGreen(button[2]);
                Correct(2);
                return;
            }
            else
            {
                setButtonRed(button[0], button[1]);
                Incorrect(0, 1);
                return;
            }
        }

        if (questionScreen == 3)
        {
            string actual = "25mph";
            string expected = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            if (actual == expected)
            {
                setButtonGreen(button[1]);
                Correct(1);
                return;
            }
            else
            {
                setButtonRed(button[0], button[2]);
                Incorrect(0, 2);
                return;
            }
        }

        if (questionScreen == 4)
        {
            string actual = "Car1";
            string expected = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
            if (actual == expected)
            {
                setButtonGreen(button[1]);
                Correct(1);
                return;
            }
            else
            {
                setButtonRed(button[0], button[2]);
                Incorrect(0, 2);
                return;
            }
        }
    }

    public void setButtonGreen(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.green;
        //cb.highlightedColor = Color.green;
        //cb.pressedColor = Color.green;
        cb.selectedColor = Color.green;
        button.colors = cb;
    }

    public void setButtonRed(Button button1, Button button2)
    {
        ColorBlock cb1 = button1.colors;
        cb1.normalColor = Color.red;
        //cb1.highlightedColor = Color.red;
        //cb1.pressedColor = Color.red;
        cb1.selectedColor = Color.red;
        button1.colors = cb1;
        ColorBlock cb2 = button2.colors;
        cb2.normalColor = Color.red;
        //cb2.highlightedColor = Color.red;
        //cb2.pressedColor = Color.red;
        cb2.selectedColor = Color.red;
        button2.colors = cb2;
    }

    public void ResetColor()
    {
        for(int i=0; i<button.Length; i++)
        {
            ColorBlock cb = button[i].colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = Color.white;
            cb.selectedColor = Color.white;
            button[i].colors = cb;
        }
    }
}
