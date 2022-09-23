using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int HP = 50;
    public int MP = 20;
    public int Attack = 8;
    public int Strength = 6;
    public int Mobility = 4;
    public int Magic = 6;

    //string[] names = new string["10"]; Items


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        HP += Mathf.FloorToInt(Input.GetAxis("Vertical"));
        Debug.Log(HP + "----" + MP);
    }
}
