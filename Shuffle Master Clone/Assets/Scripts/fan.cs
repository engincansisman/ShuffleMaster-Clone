using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
  public Animator  _Animator;
  public float waitingTime;

  public void AnimationProcess(string situation)
  {
    if (situation=="true")
    {
      _Animator.SetBool("run",true);
    }
    else
    {
       _Animator.SetBool("run",false) ;
      StartCoroutine(AnimTimer());
    }
  }

  IEnumerator AnimTimer()
  {
    yield return new WaitForSeconds(waitingTime);
    AnimationProcess("true");
  }


  
}
