using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    

    public class CEnemyTrigger : MonoBehaviour
    {
        public GameObject theDoor; // 문
        public GameObject door; // 문 콜라이더..

        public AudioSource bgm01; // 메인 씬 1배경음
        public AudioSource bgm02; // 적 등장 사운드 

        public AudioSource doorBang; // 문열기 사운드

        public GameObject theRobot; // 적 

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            // 열기 & 문 콜라이더 제거
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled=false;
            door.GetComponent<BoxCollider>().enabled = false;

            // 문사운드
            bgm01.Stop();
            doorBang.Play();

            // 에너미 활성화
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            // 에너미 등장
            bgm02.Play();

            // Enemy 타겟을 향해 걷기 
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot!= null)
            {
                robot.SetState(RobotState.R_walk);
            }


            // 트리거 킬
            Destroy(this.gameObject);



           

            
        }
    }
}