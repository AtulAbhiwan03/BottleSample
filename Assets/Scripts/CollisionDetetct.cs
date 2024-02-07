using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetetct : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.GetComponent<Rigidbody2D>().gravityScale == 0  && other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }


        if (other.collider.gameObject.CompareTag("Ground"))
        {
            var o = gameObject;
            o.tag = "Ground";
        }
    }
}
