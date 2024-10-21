using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        #region Variables

        private Animator animator;
        // 이동
        [SerializeField] private float moveSpeed = 5f;
        
        // 입력값 
        private float moveX;
        private float moveY;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // 입력 처리
            moveX = Input.GetAxis("Horizontal"); 
            moveY = Input.GetAxis("Vertical"); 

            // 이동: 방향, 속도 
            Vector3 dir = new Vector3 (moveX, 0f, moveY);
            transform.Translate(dir.normalized* moveSpeed*Time.deltaTime,Space.World);

            //  AnimtorStateTest();
            AnimationBlendTest();
        }
        void AnimationBlendTest()
        {
            animator.SetFloat("moveX",moveX);
            animator.SetFloat("moveY", moveY);
        }


        void AnimtorStateTest()
        {
            if (moveX == 0f && moveY == 0f)
            {
                animator.SetInteger("movestate", 0); // 대기
            }
            else if(moveY >0f)
            {
                animator.SetInteger("movestate", 1); // 앞

            }
            else if(moveY < 0f)
            {
                animator.SetInteger("movestate", 2); // 뒤

            }
            else if(moveX < 0f)
            {
                animator.SetInteger("movestate", 3); // 왼

            }
            else if(moveX > 0f)
            {
                animator.SetInteger("movestate", 4); // 오

            }

        }
            

        

    }

}