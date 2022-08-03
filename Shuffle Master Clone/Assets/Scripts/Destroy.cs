using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Saw"))
        {
            Debug.Log("safsd");
            GameObject.FindObjectOfType<HandleCard>().GetComponent<HandleCard>().RemoveCard(1);
            
        }

        if (other.CompareTag("fan"))
        {
            Debug.Log("fan");
            GameObject.FindObjectOfType<HandleCard>().GetComponent<HandleCard>().RemoveCard(1);
        }
        
    }
}
