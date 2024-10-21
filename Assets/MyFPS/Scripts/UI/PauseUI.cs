using StarterAssets;
using UnityEngine;

namespace MyFps
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables

        public GameObject pauseUI;

        private GameObject thePlayer;
        #endregion

        private void Start()
        {
            // 참조
            thePlayer = GameObject.Find("Player"); // 직접 이름으로 찾아옴 
        }
        private void Update()
        {
            // 일시정지 키 입력
            if(Input.GetKeyDown(KeyCode.Escape)) // && isSequence 로 일시정지시에 사운드나 시퀸스1이 진행되는지 안되는지는 기획에서   
            {
                Toggle();

            }


        }

        public void Toggle()
        {

            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf) // 퍼즈 창이 오픈 될때
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = false; // 플레이어 컨트롤 비활성화
                                                                                 // 커서 상태 설정
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f; // 정지
                
            }
            else // 퍼즈창이 클로즈 될 때 
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = true; // 플레이어 컨트롤 활성화
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f; // 다시 진행 
            }


        }
        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("Go To MainMenu!!!!!!!!!!");
        }

    }
}