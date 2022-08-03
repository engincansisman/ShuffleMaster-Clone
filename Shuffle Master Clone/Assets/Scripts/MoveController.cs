using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Lean.Touch;

public class MoveController : MonoBehaviour
{


    public HandleCard handleCard;
    public LeanManualTranslateRigidbody LeanManualTranslateRigidbody;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   

     void FixedUpdate()
     {
        
         LeanManualTranslateRigidbody.TranslateWorld(new Vector3(0,0,.08f));

         
     }
    
     private void OnTriggerEnter(Collider other)
     {
         if (other.name=="X2"&& HandleCard.Instance.hand==HandleCard.MyEnum.left)
         {
             
             HandleCard.Instance.AddCard(HandleCard.Instance.GetActiveCardCount());
             other.transform.parent.gameObject.SetActive(false);
             
             
         }

         if (other.name=="+4"&& HandleCard.Instance.hand==HandleCard.MyEnum.right)
         {
             HandleCard.Instance.AddCard(4);
             other.transform.parent.gameObject.SetActive(false);


         }

         if (other.name=="-3"&& HandleCard.Instance.hand==HandleCard.MyEnum.left)
         {
             HandleCard.Instance.RemoveCard(3);
             other.transform.parent.gameObject.SetActive(false);
         }
         
         if (other.name=="+2"&& HandleCard.Instance.hand==HandleCard.MyEnum.right)
         {
             HandleCard.Instance.AddCard(2);
             other.transform.parent.gameObject.SetActive(false);


         }
         
         if (other.name=="-2"&& HandleCard.Instance.hand==HandleCard.MyEnum.left)
         {
             HandleCard.Instance.RemoveCard(2);
             other.transform.parent.gameObject.SetActive(false);
         }
        
         if (other.name=="+5"&& HandleCard.Instance.hand==HandleCard.MyEnum.right)
         {
             HandleCard.Instance.AddCard(5);
             other.transform.parent.gameObject.SetActive(false);


         }
         
         
     }
}
