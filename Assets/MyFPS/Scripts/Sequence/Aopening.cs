using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFps
{
    public class Aopening : MonoBehaviour
    {
        #region Variables

        // 
        public GameObject thePlayer;
        public SceneFader Fader;

        // 시퀀스 텍스트
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence01 = ".....Where am I?";
        [SerializeField] private string sequence02 = "I Need Get Out Of Here";

        // 플레이어 음성 사운드
        public AudioSource line01;
        public AudioSource line02;

        #endregion
        void Start()
        {
            // 커서 상태 설정
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(PlaySequence());
        }

        // 오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            // 0. 플레이 캐릭터 비 활성화
              thePlayer.GetComponent<FirstPersonController>().enabled = false;    // 시작시 플레이어 컨트롤만 잠금
           // thePlayer.SetActive(false); 

            // 1. 페이드 인 연출( @초 대기 후 페이드 인 효과 )
              Fader.FromFade(4f);  // 5초 동안 페이드 효과


            // 2. 화면 하단에 시나리오 텍스트 화면 출력(3초), 음성 출력
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play(0);

            yield return new WaitForSeconds(3f);

            textBox.text = sequence02;
            line02.Play(0);

            // 3. 3초후에 시나리오 텍스트 없어진다 2가지 방법
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);


            // 4. 플레이 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
          //thePlayer.SetActive(true);



          
        }

    }
}