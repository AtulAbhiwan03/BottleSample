using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D selectedObject = null;


   
    void Update()
    {
        // Check for touch or mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the screen position where the user clicked
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            // If the ray hits an object with a Rigidbody2D component
            if (hit.collider != null && hit.collider.GetComponent<Rigidbody2D>() != null)
            {
                // Select the object
                selectedObject = hit.collider.GetComponent<Rigidbody2D>();
            }
        }
        else if (Input.GetMouseButton(0) && selectedObject != null)
        {
            // Move the selected object along with the mouse
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedObject.MovePosition(newPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Deselect the object
            selectedObject = null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.collider.CompareTag("LeftWall") || collision.collider.CompareTag("RightWall"))
        {
            Debug.Log("Hree");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
        }*/
    }
}
