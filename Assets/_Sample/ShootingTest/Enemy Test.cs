using MyFps;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MySample
{
    public class EnemyTest : MonoBehaviour,IDamageable
    {
        #region Variables

        // 체력
        [SerializeField] private float maxhealth = 20;

        private float currenthealth;

        private bool isDeath = false; // 중복사망 방지


        #endregion

        void Start ()
        {
            currenthealth = maxhealth;
            isDeath = false;
        }
        public void TakeDamage(float damage)
        {
            currenthealth -= damage;
            Debug.Log($"currenthealth:{currenthealth}");

            // 데미지 효과,  

            if (currenthealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;

            // 보상 - 리워드 -> 경험치,돈, 


            // 효과


            // 죽음 처리 
            Destroy(gameObject);

        }

    }
}