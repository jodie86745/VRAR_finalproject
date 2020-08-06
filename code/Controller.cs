using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    int len = 0;

    string show = "";
    private string outString;
    private string warningString;
    private string taskString;
    private int flag = 0;
    private int count = 0;
    public Text TalkBar;
    public Canvas TalkUI;


    public Text TalkText;
    public Image TalkGround;

    public Text taskText;
    public Image taskImage;

    public Text WarningText;
    public Image WarningImage;

    public GameObject lightGameObject;

    public Image Img_Chen;
    public Image Img_Me;


    int talktrigger = 0;
    int stopopenUI = 0;

    int startWarning = 0;

    int taskcount = 0;

    int warningcount = 0;

    int showHead_Chen = 0;
    int showHead_Me = 0;

    public int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        TalkUI.enabled = false;
        Img_Chen.enabled = false;
        Img_Me.enabled = false;
    }



    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.Translate(Vector3.forward * movespeed);
        //if (Input.GetKey(KeyCode.DownArrow))
        //    //transform.Translate(-Vector3.forward * movespeed);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //if (Input.GetKey(KeyCode.Mouse1) && flag ==1 )
        Light light = lightGameObject.GetComponent<Light>();
        if (light.intensity >= 1.8 && stopopenUI == 0)
        {
            talktrigger = 1;
            TalkUI.enabled = true;
            WarningImage.enabled = false;
            WarningText.enabled = false;
            taskImage.enabled = false;
            taskText.enabled = false;

        }



        //    transform.Rotate(Vector3.up, -turnspeed);
        //if (Input.GetKey(KeyCode.RightArrow))
        //if (Input.GetKey(KeyCode.Mouse0) && flag == 1)
        if (Input.GetMouseButtonDown(0) && talktrigger == 1 && state == 1 && len == 0)
        {
            flag = 2;
        }

        if (Input.GetMouseButtonUp(0) && flag == 2 && talktrigger == 1 && state == 1 && len == 0)
        {
            count++;
            UpdateTalking();
            UpdateTask();
            UpdateWarning();
        }

        if (Input.GetMouseButtonDown(0) && talktrigger == 1 && state == 0)
        {
            flag = 2;
        }

        if (Input.GetMouseButtonUp(0) && flag == 2 && talktrigger == 1 && state == 0)
        {
            TalkGround.enabled = false;
            TalkText.enabled = false;
        }


        //    transform.Rotate(Vector3.up, turnspeed);
    }

    private void UpdateTalking()
    {

        switch (count)
        {
            case 1:
                outString = "主角:阿.....頭好痛.....我怎麼昏倒了....";

                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 2:
                outString = "小陳:老師!老師您聽得到我的聲音嗎?! ";
                showHead_Chen = 1;
                showHead_Me = 0;
                showHead();
                break;
            case 3:
                outString = "主角:恩我聽到了........ ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 4:
                outString = "小陳:阿太好了!因為我這邊看不到發生了甚麼狀況，老師您一直沒有回覆我，想說是不是發生了甚麼事情... ";
                showHead_Chen = 1;
                showHead_Me = 0;
                showHead();
                break;
            case 5:
                outString = " 小陳:老師有順地抵達患者的意識裡面嗎?";
                showHead_Chen = 1;
                showHead_Me = 0;
                showHead();
                break;
            case 6:
                outString = "主角:有的，應該是剛剛傳送時出了一點問題，我失去聯絡大概多久了呢? ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 7:
                outString = "小陳:大概半個小時 ";
                showHead_Chen = 1;
                showHead_Me = 0;
                showHead();
                break;
            case 8:
                outString = "主角:(原來我昏了這麼久嗎)抱歉讓你擔心了 ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 9:
                outString = "小陳:恩恩沒事就好!如果過程中有出甚麼緊急狀況再隨時連絡我! ";
                showHead_Chen = 1;
                showHead_Me = 0;
                showHead();
                break;
            case 10:
                outString = "主角:好的那就先這樣了，謝謝你 ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 11:
                outString = " <<對話結束>>";
                showHead_Chen = 0;
                showHead_Me = 0;
                showHead();
                break;
            case 12:
                outString = "主角:(等等從諮商室出去就可以進入患者的潛意識裡了，但得先找到日記才行，不然沒辦法開始調查) ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 13:
                outString = "主角:(應該掉在這附近才對) ";
                showHead_Chen = 0;
                showHead_Me = 1;
                showHead();
                break;
            case 14:
                //talktrigger = 0;
                //TalkUI.enabled = false;
                showHead_Chen = 0;
                showHead_Me = 0;
                showHead();
                TalkGround.enabled = false;
                TalkText.enabled = false;
                taskImage.enabled = true;
                taskText.enabled = true;
                stopopenUI = 1;
                startWarning = 1;
                state = 0;
                break;

            default: break;
        }

        //TalkBar.text = count + ". " + outString;
        //TalkBar.text = outString;
        len = outString.Length;
        //Invoke("nothing", 1);
        //flag = 0;
    }

    void Update()
    {
        //int len = temp.Length;
        Invoke("nothing", 1);
    }







    public void nothing()
    {
        if (len != 0)
        {
            show = show + outString[outString.Length - len];
            TalkBar.text = show;
            len--;
        }
        else
        {
            show = "";
        }
    }


    private void UpdateTask()
    {
        switch (taskcount)
        {
            case 0: taskString = "找到日記(0/1)"; break;
            case 1: taskString = "找到日記(1/1)"; break;
            default: break;
        }

        taskText.text = taskString;
    }

    private void UpdateWarning()
    {
        switch (warningcount)
        {
            case 0: warningString = "應該先找到日記再出去"; break;
            default: break;
        }
        WarningText.text = warningString;
    }

    private void showHead()
    {
        if (showHead_Chen == 1) Img_Chen.enabled = true;
        else Img_Chen.enabled = false;

        if (showHead_Me == 1) Img_Me.enabled = true;
        else Img_Me.enabled = false;
    }

}
