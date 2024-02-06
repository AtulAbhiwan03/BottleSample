using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObjectIntraction : MonoBehaviour
{
    public float moveSpeed = 5f; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rb.AddForce(randomDirection * moveSpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Vector3 mousePosition;
            if (Input.touchCount > 0)
            {
                mousePosition = Input.GetTouch(0).position;
            }
            else
            {
                mousePosition = Input.mousePosition;
            }
            
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f)); // The z-coordinate is set to 10f, adjust as needed
            transform.position = worldMousePosition;
        }
    }
}
