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
}
