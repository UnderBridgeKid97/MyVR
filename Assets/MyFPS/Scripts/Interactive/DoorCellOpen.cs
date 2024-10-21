using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
      
        // 액션
        private Animator animator;
        private Collider m_collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<Collider>();
        }
        
        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_collider.enabled = false;
            audioSource.Play();
        }
    }
}