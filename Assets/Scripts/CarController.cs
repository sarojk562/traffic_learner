using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Public variables for controlling the car's movement
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    private Vector3 previousPosition;
    public GameObject gameOver, pauseCanvas;
    float currentSpeed;
    private bool gamePaused = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                pauseCanvas.SetActive(false);
                gamePaused = false;
                Time.timeScale = 1f;
            }
            else
            {
                pauseCanvas.SetActive(true);
                gamePaused = true;
                Time.timeScale = 0f;
            }
        }

        // Get the horizontal and vertical axis input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the car forward or backward based on the vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Rotate the car left or right based on the horizontal input and direction of movement
        if (verticalInput != 0)
        {
            float turningDirection = Mathf.Sign(verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput * turningDirection);
        }

        currentSpeed = Vector3.Distance(transform.position, previousPosition) / Time.deltaTime;

        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("NextLevel") )
        {
            Invoke("CheckWin", 5f);
        }

        if(other.gameObject.CompareTag("StopSign"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        if(other.gameObject.CompareTag("CorrectWay"))
        {
            Invoke("WinLevel", 5f);
        }

        if(other.gameObject.CompareTag("NPC"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CheckWin()
    {
        if (currentSpeed <= 0.5f)
        {
            LevelManager.LoadLevelSelection();
        }
    }

    public void WinLevel()
    {
        LevelManager.LoadLevelSelection();
    }

}
