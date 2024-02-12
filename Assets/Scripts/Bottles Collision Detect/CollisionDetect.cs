using System;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public int requiredGroundCount = 350;
    public static Action ActivateBottel;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.GetComponent<Rigidbody2D>().gravityScale == 0  && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("<color=yellow> Collided with Player tag </color>");
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        if (other.gameObject.tag == "Ground")
        {
            gameObject.tag = "Ground";
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }


        int groundCount = GameObject.FindGameObjectsWithTag("Ground").Length;

        if (groundCount >= requiredGroundCount)
        {
           ActivateBottel?.Invoke();

        }

    }



}
