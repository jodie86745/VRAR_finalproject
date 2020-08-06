using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game_Sugar : MonoBehaviour
{
    //private Game_Cups_React CupScript;
    private Game_Tasks TaskScript;

    public bool playing = false;
    public bool show_success = false;

    int[] player_hit = new int[6];
    int count = 0;
    int[] answer = new int[6];
    int answer_num;

    public int hitting = -1;

    public Text End_Round;

    // Start is called before the first frame update
    void Start()
    {
        TaskScript = GameObject.Find("Radio").GetComponent<Game_Tasks>();

        End_Round.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Pos.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);*/

        if(TaskScript.cur_State == Game_Tasks.GameState.Game)
        {
            if(playing)    // 
            {
                // sugar hit
                //if(hitting >= 0)
                    Judgement(TaskScript.round);
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cup_01")
        {
            hitting = 3;
        }
        if(collision.gameObject.tag == "Cup_02")
        {
            hitting = 2;
        }
        if(collision.gameObject.tag == "Cup_03")
        {
            hitting = 1;
        }
        if(collision.gameObject.tag == "Cup_04")
        {
            hitting = 0;
        }

        Debug.Log(collision.gameObject.name);
    }

    private void Hit_Cup(GameObject cup)
    {
        //print(cup.name);
        // the cup that player is hit
        if(cup.tag == "Cup_01")
        {
            hitting = 3;
        }
        if (cup.tag == "Cup_02")
        {
            hitting = 2;
        }
        if (cup.tag == "Cup_03")
        {
            hitting = 1;
        }
        if (cup.tag == "Cup_04")
        {
            hitting = 0;
        }

        Judgement(TaskScript.round);

    }

    private void Judgement(int round)
    {
        //Debug.Log("judgement");
        if(hitting == -1)
        {
            //Debug.Log("no hit");
            return;
        }
        else
        {
            //Debug.Log("hit");
            // check round
            if(round == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    answer[i] = TaskScript.r_1[i];
                }
                //answer = TaskScript.r_1;
                answer_num = 4;
            }
            else if(round == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    answer[i] = TaskScript.r_2[i];
                }
                answer_num = 5;
            }
            else if(round == 3)
            {
                for (int i = 0; i < 6; i++)
                {
                    answer[i] = TaskScript.r_3[i];
                }
                answer_num = 6;
            }

            // correct or wrong
            if(count < answer_num)
            {
                // count = 0
                if(hitting == answer[count]) // if correct
                {
                    count++;
                    Debug.Log("hit" + hitting.ToString());
                }
                else    // wrong
                {
                    count = 0;
                }
            }

            if(count == answer_num) // finish round
            {
                count = 0;
                playing = false;
                TaskScript.fin_round = true;
                
                Debug.Log("Finish round");

                show_success = true;
                if(round < 3)
                    End_Round.text = "Success";
                Invoke("Hide_Text", 3);
            }

            hitting = -1;
        }
    }

    void Hide_Text()
    {
        End_Round.text = "";
        show_success = false;
    }
}
