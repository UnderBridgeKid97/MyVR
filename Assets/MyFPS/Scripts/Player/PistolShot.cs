using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace MyFps
{
    public class PistolShot : MonoBehaviour
    {
        #region Variables

       
        private Animator animator;
        //
        public ParticleSystem muzzle;
        public AudioSource pistolshot;

        // public Transform camera;
        public Transform firePoint;

        // 공격
        [SerializeField]private float attackDamage = 5f;


        // 연사 딜레이 
        [SerializeField]private float fireDelay = 0.5f;
        private bool isFire = false;

        // 임팩트
        public GameObject hitImpactPrefab;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
           // 참조
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // 슛
            if(Input.GetButtonDown("Fire")&& !isFire)
            {
                if(PlayerStats.Instance.UseAmmo(1)==true)
                {
                    StartCoroutine(shoot());
                }
            }


        }

        IEnumerator shoot()
        {
            isFire = true;
            // 내앞에 100안에 적이 있으면 적에게 데미지를 준다 
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                // 적에게 대미지를 준다
                Debug.Log($"{hit.transform.name}적에게 데미지를 준다");

                // 임팩트효과 
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);


                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null )
                {
                    damageable.TakeDamage(attackDamage);
                }


               /* RobotController robot = hit.transform.GetComponent<RobotController>();

                if (robot != null)
                {
                    robot.TakeDamage(attackDamage);
                }*/
            }


            // 슛효과 - vfx, sfx
            animator.SetTrigger("Fire");

            pistolshot.Play();

            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;

        }
        // 기즈모 그리기: 총 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기

        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit) // 레이저에 맞으면
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance); // 히트한 오브젝트
            }
            else // 레이저에 맞으게 없으면
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }


        }

    }
}