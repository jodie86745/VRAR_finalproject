using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;

public class Game_Tasks : MonoBehaviour
{
    public AudioClip[] music = new AudioClip[4];
    public int[] r_1 = new int[] { 0, 1, 2, 3 };
    public int[] r_2 = new int[] { 1, 3, 2, 1, 0 };
    public int[] r_3 = new int[] { 2, 0, 3, 2, 1, 3 };
    int count = 0;

    public bool isTaskPlaying = false;  // check wether the music is play

    public Text Round_Title;
    int title_anim = 0;

    private AudioSource music_task;

    //private Game_Player PlayerScript;
    private Game_Cups_React CupScript;
    private Sugar SugarScript;

    public bool fin_round = false;
    public int round = 1;

    public enum GameState
    {
        //Begin,
        Ready,
        Game,
        Over,
        Exit
    }

    public GameState cur_State = GameState.Ready;

    // Start is called before the first frame update
    void Start()
    {
        music_task = GetComponent<AudioSource>();

       // PlayerScript = GameObject.FindGameObjectWithTag("Straw").GetComponent<Game_Player>();
        CupScript = GameObject.FindGameObjectWithTag("Cup_01").GetComponent<Game_Cups_React>();
        SugarScript = GameObject.FindGameObjectWithTag("Sugar").GetComponent<Sugar>();

        Round_Title.text = " ";
    }

    void OnGUI()
    {
        if (cur_State == GameState.Ready)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), GameStartConfirm, "Mission");
        }
        else if (cur_State == GameState.Game && title_anim == 0)
        {
            /* 
            //GUI.Window(2, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), GameRestartConfirm, "Round");
            if(PlayerScript.show_success == false)
            {
                Round_Title.text = "Round " + round.ToString();
                Invoke("Hide_Title", 2);

                //title_anim = 1;
            } */

            if(SugarScript.show_success == false)
            {
                Round_Title.text = "Round " + round.ToString();
                Invoke("Hide_Title", 2);

                //title_anim = 1;
            }

        }
        else if (cur_State == GameState.Over && fin_round == true)
        {
            GUI.Window(2, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), GameRestartConfirm, "Success");
        }
    }

    void GameStartConfirm(int ID)
    {
        if (GUI.Button(new Rect(50, 30, 100, 20), "Start"))
        {
            cur_State = GameState.Game;
        }
    }

    void GameRestartConfirm(int ID)
    {
        if (GUI.Button(new Rect(50, 30, 100, 20), "Exit"))
        {
            cur_State = GameState.Exit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* if(cur_State == GameState.Game && fin_round == false && PlayerScript.playing == false)
        {
            if(title_anim == 1)
            {
                //Thread.Sleep(1000);
                //title_anim = 2;
            }
            else if(title_anim == 2)
            {
                Task_Start();
            }
        }*/
        if(cur_State == GameState.Game && fin_round == false && SugarScript.playing == false)
        {
            if(title_anim == 1)
            {
                //Thread.Sleep(1000);
                //title_anim = 2;
            }
            else if(title_anim == 2)
            {
                Task_Start();
            }
        }
        else if(cur_State == GameState.Game && fin_round == true)
        {
            title_anim = 0;
            fin_round = false;
            round++;
            Debug.Log("next round is: " + round.ToString());
            cur_State = GameState.Over;
        }
        else if(cur_State == GameState.Over)
        {
            if(round < 4)
            {
                //Task.Delay(3000);
                //Thread.Sleep(3000);     // wait for 3s
                //cur_State = GameState.Game;
                Invoke("Round_Change", 2);
            }
            else
            {
                fin_round = true;
                title_anim = 0;
            }
        }
    }   

    void Round_Change()
    {
        cur_State = GameState.Game;
    }
                      
    void Hide_Title()
    {
        Round_Title.text = " ";
        title_anim = 2;
    }

    void Task_Start()
    {
        isTaskPlaying = true;

        int music_num = 0;

        if(round == 1)
        {
            music_num = 4;
        }
        else if(round == 2)
        {
            music_num = 5;
        }
        else if (round == 3)
        {
            //Debug.Log("Enter Round 3");
            music_num = 6;
        }

        //-----
        if (!music_task.isPlaying)
        {
            if (count < music_num)
            {
                if(round == 1)
                {
                    music_task.clip = music[r_1[count]];
                }
                else if(round == 2)
                {
                    music_task.clip = music[r_2[count]];
                    //Debug.Log("round 2 music");
                }
                else if(round == 3)
                {
                    music_task.clip = music[r_3[count]];
                }
                music_task.Play();
                count++;
            }
            else
            {
                //Debug.Log("enter player mode");
                count = 0;
                isTaskPlaying = false;
                //PlayerScript.playing = true;
                SugarScript.playing = true;
            }
        }
        //----
    }
}
