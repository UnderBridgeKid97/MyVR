using TMPro;
using UnityEngine;

namespace MyFps
{
    // 인터렉티브 액션을 구현하는 클래스 
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction(); // 추상클래스 
        

        #region Variables
        private float theDistance;

        // actionUI
        public GameObject ActionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

       
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        private void OnMouseOver()
        {
            // 거리가 2이하일때
            if (theDistance <= 2f)
            {
                ShowActionUI();

                // 문이 열리는 액션
                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    // Action
                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        private void OnMouseExit()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            ActionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            ActionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }

      
    }
}