using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetetct : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
