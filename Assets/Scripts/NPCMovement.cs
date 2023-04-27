using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
