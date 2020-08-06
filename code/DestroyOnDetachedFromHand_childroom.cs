//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Destroys this object when it is detached from the hand
//
//=============================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class DestroyOnDetachedFromHand_childrenroom : MonoBehaviour
	{
        
        public Canvas TalkUI;
        public Text TalkBar;
        public Image TalkGround;
       
        public Text taskText;
        
        public Image taskImage;
        public Text TalkText;
        private int flag = 0;
        private int state = 0;
        private string taskString;
        
        public GameObject myCanvas;
        //public int find=0;
        public GameObject connect;

        private string outString;
        int showHead_Chen = 0;
        int showHead_Me = 0;
        public Image Img_Chen;
        public Image Img_Me;
        


        //-------------------------------------------------
        private void OnDetachedFromHand( Hand hand )
		{
			gameObject.active = false;
            taskString = "找到日記(1/1)";
            taskText.text = taskString;

            TalkUI.enabled = true;

            TalkGround.enabled = true;
            TalkText.enabled = true;
            showHead_Chen = 0;
            showHead_Me = 1;
            showHead();
            
            TalkBar.text = "找到日記了，那麼走吧";
            Invoke("close",3);
            Invoke("load", 3);
            //myCanvas.GetComponent<Controller>().state = 0;
            //find = 1;
            connect.GetComponent<movements > ().find = 1;
            //movements.find = 1;

        }

        public void load()
        {
            SceneManager.LoadScene("兒童房");

        }

        private void showHead()
        {
            if (showHead_Chen == 1) Img_Chen.enabled = true;
            else Img_Chen.enabled = false;

            if (showHead_Me == 1) Img_Me.enabled = true;
            else Img_Me.enabled = false;
        }

        private void close()
        {
            TalkGround.enabled = false;
            TalkText.enabled = false;
            Img_Me.enabled = false;
        }
        
    }
}
