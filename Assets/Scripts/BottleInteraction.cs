using UnityEngine;

public class BottleInteraction : MonoBehaviour
{
    private Rigidbody2D selectedObject = null;


    #region Select particular object with raycast in editor

    // This code is usable when i have to select and move a particular object in the scene    // Working for android 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.GetComponent<Rigidbody2D>() != null)
            {
                selectedObject = hit.collider.GetComponent<Rigidbody2D>();
            }
        }
        else if (Input.GetMouseButton(0) && selectedObject != null)
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedObject.MovePosition(newPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }

    #endregion


    #region Collision Test  Previous Code
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

    #endregion


    #region Test code for touch in android and editor

 
    /*void Update()
    {
        // Check for touch or mouse input
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 inputPosition = Input.GetMouseButtonDown(0) ? (Vector2) Input.mousePosition : Input.GetTouch(0).position;
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(inputPosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.GetComponent<Rigidbody2D>() != null)
            {
                selectedObject = hit.collider.GetComponent<Rigidbody2D>();
            }
        }
        else if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && selectedObject != null)
        {
            Vector2 inputPosition = Input.GetMouseButton(0) ? (Vector2) Input.mousePosition : Input.GetTouch(0).position;
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(inputPosition);
            selectedObject.MovePosition(newPosition);
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            selectedObject = null;
        }
    }*/
       

    #endregion
}
