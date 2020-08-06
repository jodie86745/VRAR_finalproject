using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Cups_React : MonoBehaviour
{
    private Game_Tasks TaskScript;
    private Game_Sugar SugarScript;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        TaskScript = GameObject.Find("Radio").GetComponent<Game_Tasks>();
        SugarScript = GameObject.FindGameObjectWithTag("Sugar").GetComponent<Game_Sugar>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        if(TaskScript.cur_State == Game_Tasks.GameState.Game && TaskScript.isTaskPlaying == false)
        {
            source.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sugar")
        {
            source.Play();
            //Debug.Log("Hit sugar");
            
            if(tag == "Cup_01")
            {
                SugarScript.hitting = 0;
            }
            if(tag == "Cup_02")
            {
                SugarScript.hitting = 1;
            }
            if(tag == "Cup_03")
            {
                SugarScript.hitting = 2;
            }
            if(tag == "Cup_04")
            {
                SugarScript.hitting = 3;
            }
        }
    }
}
