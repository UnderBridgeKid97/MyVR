using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

namespace MyFps
{


    // 정면에 있는 충돌체와의 거리
    

    public class PlayerCasting : MonoBehaviour
    {
        #region Variable
        public static float distanceFromTarget= Mathf.Infinity; //- 시작시 커서가 문에 잇으면 e키가 보이는 버그 수정
        [SerializeField]private float toTarget; // 거리 숫자 보기
        #endregion

        private void Start()
        {
          // 초기화 
          //  distanceFromTarget = Mathf.Infinity;
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
           if( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit))
            {
               distanceFromTarget = hit.distance;
                toTarget=distanceFromTarget;
            }
        }

        // 기즈모 그리기: 카메라 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기

        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if(isHit) // 레이저에 맞으면
            {
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance); // 히트한 오브젝트
            }
            else // 레이저에 맞으게 없으면
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }


        }


    }
}