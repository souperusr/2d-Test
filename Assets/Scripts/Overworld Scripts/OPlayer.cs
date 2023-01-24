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

    Rigidbody2D rb;
    
    Vector2 Movement = Vector2.zero;
    public float MovementSpeed;

    public Canvas NPCCanvas;

    // Start is called before the first frame update
    void Start ()
    {
        HP = SceneData.HP;
        MP = SceneData.MP;
        
        transform.position = SceneData.Position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (NPCCanvas.enabled) 
        {            
            return;
        }
        
        Vector3 Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + (Movement * Time.deltaTime * MovementSpeed));


    }

    void SaveCurrentStats ()
    {
        SceneData.Position = transform.position;

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
            SceneData.EnemyIndex = other.gameObject.transform.GetSiblingIndex();
            SceneManager.LoadSceneAsync("FIGHT");
            
        }
        
    }
}
