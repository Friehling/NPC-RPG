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
    public int index;
    public int randomNumber;
    float sidstetid;
    public control Control;
    // Start is called before the first frame update
    void Start()
    {
        float sidstetid = Time.time;
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
        if (collider.gameObject.transform.tag == "Player" && Time.time - sidstetid > 0.1)
        {
            RandNumber();
            if (randomNumber == 9)
            {
                Control = GameObject.FindObjectOfType<control>();
                Control.UpdatePlayerPos(collider.transform.position);
                SceneManager.LoadScene(index);
            }
            Debug.Log("hit");
            Debug.Log(randomNumber);
            sidstetid = Time.time;
            
           
        }
    }
    void RandNumber()
    {
        
        if (Time.time > 1)
        {
            randomNumber = Random.Range(0, 200);
        }
    }

    
}
