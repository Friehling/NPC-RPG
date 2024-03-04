using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    public int rember = 0;
    Vector3 playerPos = new Vector3(-9, 13, 0);
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    public Vector3 GetPlayerPos()
    {
        return playerPos;
    }

    public void UpdatePlayerPos(Vector3 pos)
    {

        playerPos = pos;
    }
    public void Select0()
    {
        rember = 0;
    }
    public void Select1()
    {
        rember = 1;
    }
    public void Select2()
    {
        rember = 2;
    }
    public void Select3()
    {
        rember = 3;
    }
    public void Select4()
    {
        rember = 4;
    }
    public void Select5()
    {
        rember = 5;
    }
    public void Select6()
    {
        rember = 6;
    }
    public void Select7()
    {
        rember = 7;
    }
    public void Select8()
    {
        rember = 8;
    }
    public void Select9()
    {
        rember = 9;
    }
    public void Select10()
    {
        rember = 10;
    }
    public void Select11()
    {
        rember = 11;
    }
}
