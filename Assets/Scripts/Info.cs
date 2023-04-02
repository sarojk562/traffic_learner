using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject InfoThumbnailUI, InfoDetailUI, Show1, Show2, Show3, OKBtn, next, prev;
    public Image image;
    public Text txt1, txt2, txt3;
    private static int index = 1;
    public Image oldImage;
    public Sprite[] infoImage;

    private void Awake()
    {
        Show1.SetActive(true);
        Show2.SetActive(false);
        Show3.SetActive(false);
        prev.SetActive(false);
        OKBtn.SetActive(false);
    }

    public void showInfo()
    {
        InfoThumbnailUI.SetActive(false);
        InfoDetailUI.SetActive(true);
        string selectedImage = EventSystem.current.currentSelectedGameObject.name;

        if (selectedImage == "1")
        {
            oldImage.sprite = infoImage[0];
            txt1.text = "Hand signals are often used by traffic police officers to direct traffic";
            txt2.text = "especially in areas where traffic signals are not available or not working properly";
            txt3.text = "Hand signals include pointing, waving, or holding up a hand";
            return;
        }

        if (selectedImage == "2")
        {
            oldImage.sprite = infoImage[1];
            txt1.text = "Traffic signals can be timed to help regulate the flow of traffic";
            txt2.text = "Traffic signals are typically designed to follow a specific pattern";
            txt3.text = "In some places, traffic signals may be coordinated with other traffic management tools";
            return;
        }

        if (selectedImage == "3")
        {
            oldImage.sprite = infoImage[2];
            txt1.text = "School signs are often placed near schools and other areas";
            txt2.text = "These signs typically include a warning to drivers to slow down";
            txt3.text = "School signs can help to promote safety";
            return;
        }

        if (selectedImage == "4")
        {
            oldImage.sprite = infoImage[3];
            txt1.text = "Walk signs are commonly found at crosswalks in urban areas";
            txt2.text = "they are intended to help pedestrians safely cross busy streets";
            txt3.text = "Don't Walk sign is illuminated, pedestrians are supposed to wait for the next cycle";
            return;
        }
    }
    public void NextText()
    {
        if(index == 1)
        {
            Show1.SetActive(false);
            Show2.SetActive(true);
            Show3.SetActive(false);
            prev.SetActive(true);
            index++;
            return;
        }

        if (index == 2)
        {
            Show1.SetActive(false);
            Show2.SetActive(false);
            Show3.SetActive(true);
            next.SetActive(false);
            OKBtn.SetActive(true);
            index++;
            return;
        }

        if (index == 3)
        {
            OKBtn.SetActive(true);
            next.SetActive(false);
            return;
        }

    }

    public void PrevText()
    {
        if (index == 1)
        {
            OKBtn.SetActive(false);
            prev.SetActive(false);
            return;
        }

        if (index == 2)
        {
            Show1.SetActive(true);
            Show2.SetActive(false);
            Show3.SetActive(false);
            prev.SetActive(false);
            OKBtn.SetActive(false);
            index--;
            return;
        }

        if (index == 3)
        {
            Show1.SetActive(false);
            Show2.SetActive(true);
            Show3.SetActive(false);
            OKBtn.SetActive(false);
            next.SetActive(true);
            index--;
            return;
        }
    }

    public void setBack()
    {
        Show1.SetActive(true);
        Show2.SetActive(false);
        Show3.SetActive(false);
        next.SetActive(true);
        prev.SetActive(false);
        OKBtn.SetActive(false);
        InfoThumbnailUI.SetActive(true);
        InfoDetailUI.SetActive(false);
        index = 1;
    }
}
