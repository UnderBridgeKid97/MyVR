using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace MyFps
{
    // 로봇 상태
    public enum RobotState
    {
        R_Idle,
        R_walk,
        R_Attack,
        R_Death
    }
    // 로봇 enemy 관리 클래스 

    public class RobotController : MonoBehaviour, IDamageable
    {
        #region

        public GameObject thePlayer;
        private Animator animator;
    

        // 로봇상태
        private RobotState currentState;
        // 로봇 이전 상태
        private RobotState beforstate;

        // 체력
        [SerializeField]private float maxhealth = 20;

        private float currenthealth;

        private bool isDeath = false; // 중복사망 방지

        // 이동 속도
        [SerializeField]private float moveSpeed = 5f;

        // 공격
        [SerializeField] private float attackRange = 1.5f; // 공격 가능 범위
        [SerializeField] private float attackDamege = 5f;  // 공격 데미지
        [SerializeField] private float attackTimer = 2f;   // 공격 속도 
        private float countdown = 0f;                      // 타이머
                                                           // 
        public AudioSource bgm01; // 메인 씬 1배경음
        public AudioSource bgm02; // 적 등장 사운드 

        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();

            // 초기화
            currenthealth=maxhealth;
            isDeath = false;
            SetState(RobotState.R_Idle); // 시작시 기본대기상태로 

            countdown=attackTimer; // 여기서 어택타이머로 초기화해서 시작시 2초 후 공격하고 타이머 시작 
        }
        private void Update()
        {

            if (isDeath) return;
           
            // 타겟지정 
            Vector3 dir = thePlayer.transform.position - transform.position; // 타겟 - 내위치
            float distance = Vector3.Distance(thePlayer.transform.position,transform.position);
            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }

                // 로봇 상태 구현 / 간단한 움직임ai
                switch (currentState)
                {
                    case RobotState.R_Idle:     // 기본 대기상태 조건 없음
                        break;

                    case RobotState.R_walk:     // 플레이어를 향해 걷는다 -> (이동)
                        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                        transform.LookAt(thePlayer.transform); // 플레이어를 바라봄
                        break;

                    case RobotState.R_Attack:           //
                    if(distance >attackRange)
                    {
                        SetState(RobotState.R_walk);
                    }
                        break;

                   /* case RobotState.R_Death:            //
                        break;*/
                
            }
        }

        /*// 2초마다  공격 
        private void AttackOnTimer()
        {
            if(countdown < 0f)
            {
                // 공격
                Attack();

                // 타이머 초기화
                countdown = attackTimer;
            }
            countdown -= Time.deltaTime;
        }*/
        
        private void Attack()
        {
            
            Debug.Log("플레이어에게 데미지를 준다");
            PlayerController player = thePlayer.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage(attackDamege);
            }
        }



        // 로봇의 상태 변경 
        public void SetState(RobotState newState)
        {
            // 현재 상태 체크
            if(currentState == newState )
            {
                return;
            }

            // 이전 상태 저장
            beforstate = currentState;

            currentState = newState;

            // 상태 변경에 따른 구현 내용
            animator.SetInteger("RobotState", (int)newState);
        }

        public void TakeDamage(float damage)
        {
            currenthealth -= damage;
            Debug.Log($"Remain Heath:{currenthealth}");
            if(currenthealth <= 0 && !isDeath )
            {
                Die();
            }
        }


        private void Die()
        {
            isDeath = true;

            Debug.Log("Robot Death !");
            SetState(RobotState.R_Death);

            // 배경음 변경
            bgm02.Stop();
            bgm01.Play();

            // 충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;

        }

        
    }
}