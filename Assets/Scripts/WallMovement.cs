using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform leftWall;
    public Transform rightWall;

    /*void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        leftWall.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        rightWall.Translate(Vector2.right * -horizontalInput * speed * Time.deltaTime);
    }*/



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the distance between the two cubes
        float distance = Vector3.Distance(leftWall.position, rightWall.position);

        // Only move the cubes if the distance between them is greater than 4
        if (distance > 5)
        {
            leftWall.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
            rightWall.Translate(Vector2.right * -horizontalInput * speed * Time.deltaTime);
        }

    }
}
