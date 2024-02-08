using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerColliderDetection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collision.gameObject.layer = 3;
            Debug.Log($"<color=yellow> Bottle Cap collided with {gameObject.tag} </color>");
        }
    }
}
