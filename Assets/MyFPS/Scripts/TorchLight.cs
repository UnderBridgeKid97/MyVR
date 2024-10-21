using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

namespace MySample
{
    public class TorchLight : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;
        private Animator animator;

        private int lightMode = 0;

       

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            animator = torchLight.GetComponent<Animator>();
            lightMode = 0;

            InvokeRepeating("LightAnimation", 0f, 1f); // ★


        }

        // Update is called once per frame
        void Update()
        {
         /* if(lightMode == 0)
            {
                StartCoroutine(FlameAnimation());
            }*/
        }
       

        IEnumerator FlameAnimation()
        {
            lightMode = Random.Range(1, 4);

            animator.SetInteger("LightMode", lightMode);

            /*switch (lightMode)
            {
                    case 1:animator.SetInteger("LightMode", lightMode);
                    break;

                    case 2:
                    animator.SetInteger("LightMode", lightMode);
                    break;

                    case 3:
                    animator.SetInteger("LightMode", lightMode);
                    break;

            }*/
            yield return new WaitForSeconds(1.0f);
            lightMode = 0;
        }

        // 반복 함수
        private void LightAnimation()
        {
            lightMode=Random.Range(1, 4);
            animator.SetInteger("LightMode", lightMode);
        }

    }
}
