using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Encounter : MonoBehaviour
{
    public bool switchScene = false;
    public int index;
    public GameObject player;
    public int randomNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetEncounter()
    {
        
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.transform)
        {
           randomNumber = Random.Range(0, 100);
            if (randomNumber == 9)
            {
              SceneManager.LoadScene(index);
            }
            Debug.Log("hit");
            
           
        }
    }

    
}
