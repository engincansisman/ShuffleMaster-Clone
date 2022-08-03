using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PrefabCard;

    private HandleCard handleCard;

    
    
    [SerializeField] GameObject player;
    // Start is called before the first frame update
     void Awake()
     {
         handleCard = player.GetComponent<HandleCard>();
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
          
        }
    }
}
