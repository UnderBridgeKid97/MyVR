using UnityEngine;

namespace MyFps
{
    // 총알상자 아이템 획득
    public class PickupAmmoBox : Interactive
    {
        #region Variables
        // 총알 상자 아이템 획득시 지급하는 ammo갯수
        [SerializeField]private int giveAmmo = 7;


        #endregion

        protected override void DoAction()
        {
            // 아이템 지급
            Debug.Log("탄환 7개 지급했습니다.");
            PlayerStats.Instance.AddAmmo(giveAmmo);

            // 킬
            Destroy(gameObject);
        }
    }
}