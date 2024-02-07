using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakwaas : MonoBehaviour
{
   public List<Transform> bakwaasList = new List<Transform>();
   public GameObject objectRef;


   private void Start()
   {
      foreach (var s in bakwaasList)
      {
         var p = Instantiate(objectRef);
         p.transform.position = s.position;

      }
   }
}
