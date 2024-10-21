using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFps
{
    public class FirstTrigger : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;
        public GameObject arrow;

        // 시퀀스 텍스트
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";

        public AudioSource line03;
        #endregion

        void Start()
        {
        }

       
        private void OnTriggerEnter(Collider other)
        {
            
            StartCoroutine(PlaySequence());
        }

        // 
        IEnumerator PlaySequence()
        {
            // 캐릭터 비활성화(플레이어 멈춤)
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // 대사출력  "Looks like a weapon on that table.", 음성출력
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            line03.Play();

            // 1초 딜레이
            yield return new WaitForSeconds(2f);

            // 화살표 출력
            arrow.SetActive(true);

            // 1초 딜레이
            yield return new WaitForSeconds(1f);

            // 초기화
            textBox.text = "";
            textBox.gameObject.SetActive(false);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;


            // 트리거 충돌체 비 활성화-킬
            Destroy(gameObject);
           // thePlayer.SetActive(true);
          //  transform.GetComponent<BoxCollider>().enabled = false;

        }
    }
}