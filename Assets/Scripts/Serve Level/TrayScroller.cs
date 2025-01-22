using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayScroller : MonoBehaviour
{
    public float scrollSpeed = 5f; // Speed at which the trays move
    public float minPositionX = -10f; // Minimum x position of the trays
    public float maxPositionX = 10f; // Maximum x position of the trays

    void Update()
    {
        // Get horizontal input (A for left, D for right)
        float moveInput = 0f;
        
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = 1f; // Move right
        }

        // Move the trays based on input
        float moveAmount = moveInput * scrollSpeed * Time.deltaTime;

        // Apply the movement while keeping the position within the bounds
        float newPositionX = Mathf.Clamp(transform.position.x + moveAmount, minPositionX, maxPositionX);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
