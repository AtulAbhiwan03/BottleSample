using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottleFilledEvent : MonoBehaviour
{
    public GameObject Bottle;
    public TMP_Text countdown;
    public Transform CapsParent;
    public int count = 3;

    private void OnEnable()
    {
        CollisionDetect.ActivateBottel += ActivateBottle;
    }

    private void OnDisable()
    {
        CollisionDetect.ActivateBottel -= ActivateBottle;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("<color=cyan> Bottle Filled </color>");
            StartCoroutine(RefillProcess());
        }

    }


    private void ActivateBottle()
    {
        Bottle.SetActive(true);
    }


    private IEnumerator RefillProcess()
    {
        yield return new WaitForSeconds(3);

        #region Make Bottle Caps Kinematics
        foreach (Transform item in CapsParent)
        {
            if (item.gameObject.layer == 3)
            {
                item.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        #endregion

        #region Countdown
        yield return new WaitForSeconds(3);

        while (count >= 0)
        {
            countdown.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
        countdown.text = "";
        #endregion

        #region Refilling
        yield return new WaitForSeconds(1);

        foreach (Transform item in CapsParent)
        {
           item.GetComponent<Rigidbody2D>().isKinematic = false;
           Bottle.SetActive(false);
           item.gameObject.layer = 0;
           item.gameObject.tag = "Untagged";
        }

        yield return new WaitForSeconds (2);
        SceneManager.LoadScene(0);
        #endregion
    }






}



