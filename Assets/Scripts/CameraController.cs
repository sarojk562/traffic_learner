using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the car's Transform component
    public Vector3 offset; // Offset between the camera and the car
    public float smoothSpeed = 0.125f; // Damping factor for smoothing camera movement
    public GameObject FPP, TPP, currentCamera;

    private void Start()
    {
        currentCamera = TPP;
        currentCamera.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            currentCamera.SetActive(false);
            if(currentCamera == TPP)
            {
                currentCamera = FPP;
                currentCamera.SetActive(true);
            }
            else
            {
                currentCamera = TPP;
                currentCamera.SetActive(true);
            }
        }
    }


    void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Set the camera to look at the car
        transform.LookAt(target);
    }
}
