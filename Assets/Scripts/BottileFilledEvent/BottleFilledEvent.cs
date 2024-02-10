using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottleFilledEvent : MonoBehaviour
{
    public List<Transform> transforms;
    public GameObject Bottle;
    public TMP_Text countdown;
    public Transform capParent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            foreach (Transform t in capParent)
            {
                t.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            Debug.Log("<color=cyan>Bottle filled</color>");
            StartCoroutine(Reshape());
        }

    }

    IEnumerator Reshape()
    {
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = " ";
        Bottle.SetActive(false);
        foreach (Transform t in capParent)
        {
            t.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        foreach (Transform t in capParent)
        {
            t.tag = "Untagged";
            t.gameObject.layer = 0;
        }
        yield return new WaitForSeconds(2);
        Debug.Log("Scene load");
        SceneManager.LoadScene(0);
    }

}
