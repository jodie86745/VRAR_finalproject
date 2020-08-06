using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move1 : MonoBehaviour
{

    public Canvas diaryUI;
    public Image NowImage;

    public Text debugText;

    public Sprite diary_page1;
    public Sprite diary_page2;
    public Sprite diary_page3;
    public Sprite diary_page4;
    public Sprite diary_page5;
    public Sprite diary_page6;
    public Sprite diary_page7;
    public Sprite diary_page8;
    public Sprite diary_page9;
    public Sprite diary_page10;
    public Sprite diary_page11;
    public Sprite diary_page12;
    
    //state check
    public int isDiaryOpen = 0;

    // permission
    public int canUseDiary = 0;
    public int canSummonDiary = 1;
    public int nowPage = 1;
    public int clickFlag = 0;
    public int endPage = 12;



    private Vector2 trackpad;
    private float Direction;
    private Vector3 moveDirection;
    public int find;


    public Image warningGround;
    public Text warningText;

    public AudioClip MusicClip;
    public AudioSource MusicSource;


    public SteamVR_Input_Sources Hand;//Set Hand To Get Input From
    public float speed;
    public GameObject Head;
    public CapsuleCollider Collider;
    public GameObject AxisHand;//Hand Controller GameObject
    public GameObject diary;
    public GameObject lightGameObject;
    private Light light;
    public GameObject book;

    //-----------------------------------------------------
    private Vector2 rightTrackpad;
    private Vector3 rightMoveDirection;
    private float rightDirection;
    public SteamVR_Input_Sources rightHand;
    public GameObject rightAxisHand;
    //-----------------------------------------------------


    public float Deadzone;//the Deadzone of the trackpad. used to prevent unwanted walking.

    public GameObject LightGameObject { get => lightGameObject; set => lightGameObject = value; }

    // Start is called before the first frame update

    void Start()
    {
        MusicSource.clip = MusicClip;

        diary.active = false;// 開場關閉日記UI

        Light light = lightGameObject.GetComponent<Light>();
        //light.color = Color.black;
        light.intensity = 0;

        //start forUI
        //-----------------------------------------------------
        diaryUI.enabled = false;
        //NowImage = GetComponent<Image>()
        //disableAll();
        //-----------------------------------------------------

    }


    public void openDiary()
    {
        diaryUI.enabled = true;
        canUseDiary = 1;
        isDiaryOpen = 1;
    }

    public void closeDiary()
    {
        diaryUI.enabled = false;
        canUseDiary = 0;
        isDiaryOpen = 0;
    }



    void Update()
    {

        //Set size and position of the capsule collider so it maches our head.
        Collider.height = Head.transform.localPosition.y;
        Collider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y / 2, Head.transform.localPosition.z);

        moveDirection = Quaternion.AngleAxis(Angle(trackpad) + AxisHand.transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward;//get the angle of the touch and correct it for the rotation of the controller


        //修改
        rightMoveDirection = Quaternion.AngleAxis(Angle(rightTrackpad) + rightAxisHand.transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward;



        updateInput();
        if (GetComponent<Rigidbody>().velocity.magnitude < speed && trackpad.magnitude > Deadzone)
        {//make sure the touch isn't in the deadzone and we aren't going to fast.
            GetComponent<Rigidbody>().AddForce(moveDirection * 30);
            //MusicSource.Play();
            //try to add walking sound         
        }

        if (rightTrackpad.magnitude > Deadzone && canSummonDiary == 1)
        {
            //開啟 某種東西
            if (Mathf.Abs(rightTrackpad.x) > Mathf.Abs(rightTrackpad.y))
            {
                if (rightTrackpad.x > 0)
                {
                    openDiary();
                    debugText.text = "+x";
                }
                if (rightTrackpad.x < 0)
                {
                    closeDiary();
                    debugText.text = "-x";
                }
            }

            if (Mathf.Abs(rightTrackpad.y) > Mathf.Abs(rightTrackpad.x))
            {
                if (rightTrackpad.y > 0)
                {
                    nextPage();
                    //debugText.text = "+y";
                }
                if (rightTrackpad.y < 0)
                {
                    previousPage();
                    //debugText.text = "-y";
                }
            }

        }
    }


    public static float Angle(Vector2 p_vector2)
    {
        if (p_vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }

    private void updateInput()
    {
        trackpad = SteamVR_Actions._default.MovementAxis.GetAxis(Hand);
        //修改
        rightTrackpad = SteamVR_Actions._default.MovementAxis.GetAxis(rightHand);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Door1") && find == 0)
        {
            warningGround.enabled = true;
            warningText.enabled = true;
        }
        if (col.gameObject.CompareTag("Door1") && find == 1)
        {
            SceneManager.LoadScene("兒童房");
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Door1"))
        {
            warningGround.enabled = false;
            warningText.enabled = false;
        }

    }


    public void nextPage()
    {
        debugText.text = "+y";
        if (nowPage != endPage)
        {
            nowPage += 1;
            showPage();
        }
        //tryShowPage();
    }

    public void previousPage()
    {
        debugText.text = "-y";
        if (nowPage != 1)
        {
            nowPage -= 1;
            showPage();
        }
        //tryShowPage();
    }

    public void showPage()
    {
        
        switch (nowPage)
        {
            case 1: NowImage.GetComponent<Image>().sprite = diary_page1; break;
            case 2: NowImage.GetComponent<Image>().sprite = diary_page2; break;
            case 3: NowImage.GetComponent<Image>().sprite = diary_page3; break;
            case 4: NowImage.GetComponent<Image>().sprite = diary_page4; break;
            case 5: NowImage.GetComponent<Image>().sprite = diary_page5; break;
            case 6: NowImage.GetComponent<Image>().sprite = diary_page6; break;
            case 7: NowImage.GetComponent<Image>().sprite = diary_page7; break;
            case 8: NowImage.GetComponent<Image>().sprite = diary_page8; break;
            case 9: NowImage.GetComponent<Image>().sprite = diary_page9; break;
            case 10: NowImage.GetComponent<Image>().sprite = diary_page10; break;
            case 11: NowImage.GetComponent<Image>().sprite = diary_page11; break;
            case 12: NowImage.GetComponent<Image>().sprite = diary_page12; break;
        }
        
        debugText.text = "in showpage and now count " + nowPage;
    }

    

}