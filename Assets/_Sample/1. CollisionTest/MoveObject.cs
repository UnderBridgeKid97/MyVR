using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        // 좌우로 힘을주어 이동
        [SerializeField] private float movePower = 5f;
        private float moveX;

        // 색 변경
        private Material material;
        private Color originColor;
      
        #endregion  

        void Start()
        {
            // 참조
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Renderer>().material;

            // 초기화
            originColor= material.color;
            MoveRightByForce();

        }

        void Update()
        {
            // 입력 처리
            moveX = Input.GetAxis("Horizontal");
            
        }

        private void FixedUpdate()
        {
            // 좌우로 힘주기
          //  rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);// ForceMode.Force -> 누르고있으면 계속 힘을줌

        }

        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }
        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }

        public void ChangeRedColor()
        {
            material.color = Color.red;
        }
        public void ResetColor()
        {
            material.color = originColor;
        }
    }
}