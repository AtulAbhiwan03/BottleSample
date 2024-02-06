using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed of random movement as needed

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a Rigidbody2D component
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Give the collided object a random movement direction
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            // Apply a random force to the collided object to make it move randomly
            rb.AddForce(randomDirection * moveSpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        // Check if the left mouse button is pressed or screen is touched
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // Get the current mouse position in screen coordinates
            Vector3 mousePosition;
            if (Input.touchCount > 0)
            {
                mousePosition = Input.GetTouch(0).position;
            }
            else
            {
                mousePosition = Input.mousePosition;
            }
            
            // Convert the screen position to world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f)); // The z-coordinate is set to 10f, adjust as needed
            
            // Set the position of the circle to the world mouse position
            transform.position = worldMousePosition;
        }
    }
}
