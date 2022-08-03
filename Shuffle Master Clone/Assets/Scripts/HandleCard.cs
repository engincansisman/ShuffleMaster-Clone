using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEditor.Experimental.GraphView;
using UrhobA.Singleton;



public class HandleCard : SingletonBehaviour<HandleCard>
{
    public enum MyEnum
    {
        left,
        right,
    }

    
    [SerializeField] private List<GameObject> cards = new List<GameObject>();
    
    public Transform hand1, hand2;
    public MyEnum hand=MyEnum.right;
    
    #region cardS

    

   
    private IEnumerator CardGambling(bool rotation)
    {
        if (moveTween==null&& rotTween==null)
        {
            moveTween = new Tween[cards.Count];
            rotTween = new Tween[cards.Count];
        }

        
        foreach (var m in moveTween)
        {
            m.Kill();
        }

        foreach (var r in rotTween)
        {
           r.Kill(); 
        }
        if (rotation)
        {
            hand = MyEnum.right;
            for (int i = 0; i < cards.Count; i++)
            {
            
                MoveCard(new Vector3(0,0,180f),new Vector3(0,0.5f*i,0),cards[i].transform,hand2,i);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            hand = MyEnum.left;
            for (int i = 0; i < cards.Count; i++)
            {
            
                MoveCard(new Vector3(0,0,0),new Vector3(0,0.5f*i,0),cards[i].transform,hand1,i);
                yield return new WaitForSeconds(0.02f);
            }
        }
        
    }

    

   


    private Tween[] moveTween,rotTween;
    
    private void MoveCard(Vector3 cardRotate,Vector3 cardHeight, Transform card, Transform toPoint ,int cardId )
    {
        //Vector3[] pathPoints = new Vector3[] {card.localPosition,((to.localPosition-card.localPosition)/2)+new Vector3(0,15f,0),to.localPosition };
        
        Vector3[] pathPoints = new Vector3[]
        {
            card.position, toPoint.position + Vector3.up * 5,
            toPoint.position + cardHeight/2+ Vector3.up
        };
        
        
        
        
        var path = new Path(PathType.CatmullRom,pathPoints,3);
    
        var pathTween = card.DOPath(path, .5f);
        var rotate =card.DOLocalRotate( cardRotate, .5f).SetEase(Ease.Linear);
        moveTween[cardId] = pathTween;
        rotTween[cardId] = rotate;

    }

    private bool isMoving = false;
    public void OnDrag(Vector2 delta)
    {
        if (delta.x>0.6f&&isMoving==false)
        {
            isMoving = true;

            StartCoroutine(CardGambling(false));
        }
        else if (delta.x<-0.6f && isMoving==false)
        {
            isMoving = true;

            StartCoroutine(CardGambling(true));
        }
        else
        {
            isMoving = false;
        }
        
            
    }
    
    #endregion


    #region MultiCards

    public void RemoveCard(int cardAmount)
    {
        
        
        int amount = cardAmount;
        for (int i = cards.Count-1; i >0; i--)
        {
            if (amount==0)
            {
                break;
                
            }
            if (cards[i].activeSelf)
            {
                cards[i].SetActive(false);
                amount--;
            }
        }
    }

    public int GetActiveCardCount()
    {
        int amount = 0;
        foreach (var card in cards)
        {
            if (card.activeSelf)
            {
                amount++;
            }
        }

        return amount;
    }
    public void AddCard(int cardAmount)
    {
        int amount = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (amount==cardAmount)
            {
                break;
                
            }
            if (!cards[i].activeSelf)
            {
                cards[i].SetActive(true);
                amount++;
            }
        }
    }


    #endregion
}
