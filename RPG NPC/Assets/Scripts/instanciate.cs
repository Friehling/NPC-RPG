using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class instanciate : MonoBehaviour
{
    public GameObject[] prefab;
    control Control;
    // Start is called before the first frame update
    void Start()
    {
       //Control = GetComponent<control>();
       Control = GameObject.Find("controller").GetComponent<control>();
        Instantiate(prefab[Control.rember], new Vector2(-9,12), Quaternion.identity);

        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
