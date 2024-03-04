using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class instanciate : MonoBehaviour
{
    public GameObject[] prefab;
    control Control;
    public Transform spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        //Control = GetComponent<control>();
        Control = GameObject.FindObjectOfType<control>();

        Instantiate(prefab[Control.rember], Control.GetPlayerPos(), Quaternion.identity);

        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
