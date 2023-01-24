using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGameManager : MonoBehaviour
{
    public GameObject enemies;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneData.Enemies.Length == 0)
        {
            SceneData.Enemies = new bool[enemies.transform.childCount];
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                SceneData.Enemies[i] = true;

            }
        }
        for (int i = 0; i < SceneData.Enemies.Length; i++)
        {
            if (SceneData.Enemies[i] == false)
            {
                enemies.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
