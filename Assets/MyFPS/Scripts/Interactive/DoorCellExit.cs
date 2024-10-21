using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]private string loadToScene = "MainScene02";

        private Animator animator;
        public AudioSource CreakyDoor; // 문여는 소리

        public AudioSource bgm01;        // 배경음

        private Collider m_collider;
        #endregion

        private void Start()
        {
            // 참조 
            animator = GetComponent<Animator>();
            m_collider=GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            // 1. 오픈 더 도아 


            // 2. 문여는 사운드
            animator.SetBool("IsOpen", true);
            m_collider.enabled = false;
            CreakyDoor.Play();


            changeScene();
        }

        void changeScene()
        {
            // 씬 마무리,....... bgm
            bgm01.Stop();



            // 다음 씬으로 이동
            fader.FadeTo(loadToScene);

        }


    }
}