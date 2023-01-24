using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string Name;
    public string[] Text;
    
    public TextMeshProUGUI NPCText;
    public TextMeshProUGUI NPCName;
    public Canvas NPCCanvas;

    OPlayer Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<OPlayer>();
        NPCCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCCanvas.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                NPCText.pageToDisplay += 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                NPCText.pageToDisplay -= 1;
            }
            if (NPCText.pageToDisplay > NPCText.textInfo.pageCount && NPCText.textInfo.pageCount > 0)
            {
                NPCCanvas.enabled = false;
                NPCText.pageToDisplay = 1;
            }
        }
    }

    void OnCollisionEnter2D ( Collision2D collision)
    {
        if (collision.gameObject.GetComponent<OPlayer>())
        {
            NPCText.text = Text[0];
            NPCName.text = Name;
            NPCCanvas.enabled = true;
        }
        
    }
}
