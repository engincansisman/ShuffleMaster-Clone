using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
  private void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("partOfDeck"))
    {
      other.GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0),ForceMode.Impulse);
    }
  }
}
