using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    public Sprite[] SUV;
    public Sprite[] Sports;
    public Sprite[] TwoSeater;
    public Image oldCar;
    public Dropdown carType;
    public Dropdown carColor;
    private string car, color;


    private void Start()
    {
        carType.onValueChanged.AddListener(OnCarTypeChanged);
        carColor.onValueChanged.AddListener(OnCarColorChanged);
    }

    void OnCarTypeChanged(int index)
    {
        // Get the selected value of the car type dropdown
        car = carType.options[index].text;

        // Update the car image
        UpdateCarImage();
    }

    void OnCarColorChanged(int index)
    {
        // Get the selected value of the car color dropdown
        Debug.Log(index);
        color = carColor.options[index].text;

        // Update the car image
        UpdateCarImage();
    }

    public void UpdateCarImage()
    {
        Debug.Log(car + " " + color);

        if (car == "SUV")
        {
            if (color == "Red")
            {
                oldCar.sprite = SUV[0];
            }
            if (color == "Black")
            {
                oldCar.sprite = SUV[1];
            }
            if (color == "Yellow")
            {
                oldCar.sprite = SUV[2];
            }
            return;
        }

        if (car == "Sports")
        {
            if (color == "Red")
            {
                oldCar.sprite = Sports[0];
            }
            if (color == "Black")
            {
                oldCar.sprite = Sports[1];
            }
            if (color == "Yellow")
            {
                oldCar.sprite = Sports[2];
            }
            return;
        }

        if (car == "2 Seater")
        {
            if (color == "Red")
            {
                oldCar.sprite = TwoSeater[0];
            }
            if (color == "Black")
            {
                oldCar.sprite = TwoSeater[1];
            }
            if (color == "Yellow")
            {
                oldCar.sprite = TwoSeater[2];
            }
            return;
        }
    }
}
