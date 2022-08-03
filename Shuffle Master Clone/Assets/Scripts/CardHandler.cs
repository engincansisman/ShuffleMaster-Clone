using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

namespace DefaultNamespace
{
    public class CardHandler:MonoBehaviour
    {
        
        
        public List<Transform> cards = new List<Transform>();
        public Transform hand1, hand2;

        
        private IEnumerator  Start()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                TransferCard(hand1,cards[i]);
                yield return new WaitForSeconds(0.2f);
            }
           
        }

        public void OnDrag(Vector2 delta)
        {
            
            Debug.Log(delta);
            
            
            
        }
        

        private void TransferCard(Transform to,Transform card)
        {
           // Vector3[] pathPoints = new Vector3[] {card.localPosition,((to.localPosition-card.localPosition)/2)+new Vector3(0,15f,0),to.localPosition };
           Vector3[] pathPoints = new Vector3[] {card.localPosition,to.localPosition,to.localPosition+new Vector3(0,15f,0) };
            Path path=new Path(PathType.CatmullRom,pathPoints,3);
            card.DOLocalPath (path, 0.5f);
            card.DOLocalRotate(card.eulerAngles + new Vector3(0, 0, 180f),0.4f,RotateMode.FastBeyond360);
        }
    }
    
}