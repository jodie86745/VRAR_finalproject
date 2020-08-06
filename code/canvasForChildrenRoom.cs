using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasForChildrenRoom : MonoBehaviour
{

    //取代用文字
    private string talkString;
    private string warningString;
    private string taskString;

    //畫布
    public Canvas UI;

    //counting
    private int talkCount = 0;
    private int taskCount = 0;

    //state
    private int canCountTalk = 1;
    private int canTalk = 0;

    private int clickFlag = 0;

    //底圖與文字框
    public Text talkText;
    public Image talkGround;

    public Text taskText;
    public Image taskGround;

    public Text warningText;
    public Image warningGround;
    public Image diary;
    public Image page1;
    //人像
    public Image Img_Chen;
    public Image Img_Me;


    int talktrigger = 0;
    int stopopenUI = 0;

    int startWarning = 0;

    public int taskcount = 0;
    int warningcount = 0;

    int showHead_Chen = 0;
    int showHead_Me = 0;

    int showimage_page = 0;
    int showimage_page1 = 0;


    // Start is called before the first frame update
    void Start()
    {
        UI.enabled = true;
        closeAll();


        openTalk();
    }

    private void closeAll()
    {
        Img_Chen.enabled = false;
        diary.enabled = false;
        page1.enabled = false;
        taskGround.enabled = false;
        taskText.enabled = false;
        warningGround.enabled = false;
        warningText.enabled = false;
        talkGround.enabled = false;
        talkText.enabled = false;
    }


    private void FixedUpdate()
    {
        //    transform.Rotate(Vector3.up, -turnspeed);
        //if (Input.GetKey(KeyCode.RightArrow))
        //if (Input.GetKey(KeyCode.Mouse0) && flag == 1)


        // for Talk
        if (Input.GetMouseButtonDown(0) )
        {
            clickFlag = 1;
        }

        if (Input.GetMouseButtonUp(0) && clickFlag == 1 )
        {
            talkCount++;
            updateTalk();
            clickFlag = 0;
        }

    }

    private void updateTalk()
    {

        switch (talkCount)
        {
            case 0:
                talkString = "(先看一下日記的內容好了)";
                showHead_Me = 1;
                showHead();
                break;
            case 1:
                
                showHead_Me = 0;
                showHead();
                showimage_page = 1;
                showImage();
                closeTalk();
                //closeTalk();
                break;
             case 2:

                 showHead_Me = 0;
                 showHead();
                 showimage_page = 0;
                 showimage_page1 = 1;
                 showImage();
                 showImage1();

                 closeTalk();
                 break;

            case 3:

                showHead_Me = 0;
                showHead();
                showimage_page = 0;
                
                showImage();
                page1.enabled = false;

                openTask();


                break;
            case 4:

                showHead_Me = 0;
                showHead();
                showimage_page = 1;
                showImage();
                closeTalk();
                //closeTalk();
                break;
            case 5:

                showHead_Me = 0;
                showHead();
                showimage_page = 0;
                showimage_page1 = 1;
                showImage();
                showImage1();

                closeTalk();
                break;

            case 6:
                showHead_Me = 0;
                showHead();
                showimage_page = 0;

                showImage();
                page1.enabled = false;
                

                break;


            /* case 3:
                 showHead_Chen = 0;
                 showHead_Me = 0;
                 showHead();
                 closeTalk();
                 openTask();

            break;*/


            default: break;
        }

        talkText.text = talkString;
    }


    public void updateTask()
    {
        switch (taskCount)
        {
            case 0:
                taskString = "找到日記上提到的物品(0/5)";
                break;
            case 1:
                taskString = "找到日記上缺失的物品(1/5)";
                break;
            case 2:
                taskString = "找到日記上缺失的物品(2/5)";
                break;
            case 3:
                taskString = "找到日記上缺失的物品(3/5)";
                break;
            case 4:
                taskString = "找到日記上缺失的物品(4/5)";
                break;
            case 5:
                taskString = "找到日記上缺失的物品(5/5)";
                break;

            default: break;
        }
        taskText.text = taskString;
    }



    private void showHead()
    {
        if (showHead_Me == 1) Img_Me.enabled = true;
        else { Img_Me.enabled = false; }
        if (showHead_Chen == 1) Img_Chen.enabled = true;
        else { Img_Chen.enabled = false; }
    }

    private void showImage()
    {
        if (showimage_page == 1) diary.enabled = true;
        else { diary.enabled = false; }
    }

    private void showImage1()
    {
        if (showimage_page1 == 1) page1.enabled = true;
        else { page1.enabled = false; }
    }

    public void openTask()

    {
        updateTask();
        taskGround.enabled = true;
        taskText.enabled = true;
        
    }

    private void closeTask()
    {
        taskGround.enabled = false;
        taskText.enabled = false;
    }

    private void openTalk()
    {
        canTalk = 1;
        talkGround.enabled = true;
        talkText.enabled = true;
        updateTalk();
    }

    private void closeTalk()
    {
        canTalk = 0;
        talkGround.enabled = false;
        talkText.enabled = false;
    }
}
