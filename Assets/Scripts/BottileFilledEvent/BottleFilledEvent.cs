using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottleFilledEvent : MonoBehaviour
{
    public GameObject Bottle;
    public float time;
    public TMP_Text countdown;
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
        countdown.text = "3";
        yield return new WaitForSeconds(1); 
        countdown.text = "2";
        yield return new WaitForSeconds(1); 
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = " ";
       // Bottle.SetActive(false);
        foreach (Transform t in capParent)
        {
            t.tag = "Untagged";
            t.gameObject.layer = 0;
        }
        yield return new WaitForSeconds(1);
        Debug.Log("Scene load");
        SceneManager.LoadScene(0);
    }

}
