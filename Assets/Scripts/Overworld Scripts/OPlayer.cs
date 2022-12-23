using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OPlayer : MonoBehaviour
{
    public int HP = 50;
    public int MP = 20;

    public int MaxHP = 50;
    public int MaxMP = 20;
    public int Offense = 8;
    public int Defense = 6;
    public float FireRes = 1.2f;
    public float ElecRes = .5f;
    public int Mobility = 4;

    
    Vector2 Movement = Vector2.zero;
    public float MovementSpeed;
    
    // Start is called before the first frame update
    void Start ()
    {
        HP = SceneData.HP;
        MP = SceneData.MP;
    }

    // Update is called once per frame
    void Update ()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(Movement.x, Movement.y, 0) * Time.deltaTime * MovementSpeed;


    }

    void SaveCurrentStats ()
    {
        SceneData.HP = HP;
        SceneData.MP = MP;

        SceneData.MaxHP = MaxHP;
        SceneData.MaxMP = MaxMP;
        SceneData.Offense = Offense;
        SceneData.Defense = Defense;
        SceneData.FireRes = FireRes;
        SceneData.ElecRes = ElecRes;
        SceneData.Mobility = Mobility;
}

    void OnTriggerEnter2D ( Collider2D other )
    {
        
        if (other.gameObject.GetComponent<OEnemy>().GetType() == typeof(OEnemy))
        {
            SceneData.EnemyName = other.gameObject.GetComponent<OEnemy>().Name;
            SaveCurrentStats();
            SceneManager.LoadSceneAsync("FIGHT");
            
        }
        
    }
}
