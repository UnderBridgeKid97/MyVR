using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        

        // ActionUI
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;

        #endregion

        
       protected override void DoAction()
        {
            // Action
            realPistol.SetActive(true);
            arrow.SetActive(false);

            ammoBox.SetActive(true);
            ammoUI.SetActive(true);

            enemyTrigger.SetActive(true);


            Destroy(gameObject);
        }
    }
}