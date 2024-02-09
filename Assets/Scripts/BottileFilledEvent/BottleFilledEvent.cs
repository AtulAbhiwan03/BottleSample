using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFilledEvent : MonoBehaviour
{
    public GameObject Bottle;
    public float time;
    public Transform capParent;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Bottle filled");
            StartCoroutine(Reshape(time));

        }
           
    }



    IEnumerator Reshape(float time)
    {
        yield return new WaitForSeconds(time);
        Bottle.SetActive(false);
        foreach (Transform t in capParent)
        {
            t.tag = "Untagged";
            t.gameObject.layer = 0;
        }
    }

}
