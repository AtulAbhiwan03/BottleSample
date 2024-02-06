using System;
using UnityEngine;

public class BoundryManager : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;
    private bool isInstantiated = false;
    public GameObject prefab;
    void Start()
    {
        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        leftWall.position = new Vector2(-screenWidth / 2f, leftWall.position.y);
        rightWall.position = new Vector2(screenWidth / 2f, rightWall.position.y);
    }
    
    

    #region Old code for wall movement and setting screen bounds Working well

    /* void Update()
     {
         float horizontalInput = Input.GetAxis("Horizontal");

         // Calculate the distance between the two walls
         float distance = Vector3.Distance(leftWall.position, rightWall.position);

         // Check if the distance is greater than 5
         if (distance > 5)
         {
             // Move both walls based on input
             leftWall.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
             rightWall.Translate(Vector2.right * -horizontalInput * speed * Time.deltaTime);
         }
         else
         {
             // Move only the left wall left and the right wall right
             leftWall.Translate(Vector2.left * speed * Time.deltaTime);
             rightWall.Translate(Vector2.right * speed * Time.deltaTime);
         }

         // Clamp the position of both walls to stay within screen boundaries
         float leftWallX = Mathf.Clamp(leftWall.position.x, -screenWidth / 2f, screenWidth / 2f);
         float rightWallX = Mathf.Clamp(rightWall.position.x, -screenWidth / 2f, screenWidth / 2f);

         // Update the positions of the walls after clamping
         leftWall.position = new Vector2(leftWallX, leftWall.position.y);
         rightWall.position = new Vector2(rightWallX, rightWall.position.y);
     }

     // Calculate the screen width once at the start
     float screenWidth;

     void Start()
     {
         screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
    }*/

    #endregion
    
    
    #region Wall Movement Old Code

    /*void Update()
  {
      float horizontalInput = Input.GetAxis("Horizontal");
      float distance = Vector3.Distance(leftWall.position, rightWall.position);
      if (distance > 5)
      {
          leftWall.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
          rightWall.Translate(Vector2.right * -horizontalInput * speed * Time.deltaTime);
      }
      else
      {
          leftWall.Translate(Vector2.left * speed * Time.deltaTime);
          rightWall.Translate(Vector2.right * speed * Time.deltaTime);
      }

      float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
      float leftWallX = Mathf.Clamp(leftWall.position.x, -screenWidth / 2f, screenWidth / 2f);
      float rightWallX = Mathf.Clamp(rightWall.position.x, -screenWidth / 2f, screenWidth / 2f);

      leftWall.position = new Vector2(leftWallX, leftWall.position.y);
      rightWall.position = new Vector2(rightWallX, rightWall.position.y);
  }
  */

    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isInstantiated)
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)); // The z-coordinate is set to 10f, adjust as needed
            GameObject bb =  Instantiate(prefab);
            bb.transform.position = worldMousePosition;
            isInstantiated = true;

        }
    }
}
