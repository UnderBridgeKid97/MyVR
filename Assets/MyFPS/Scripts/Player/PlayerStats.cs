using UnityEngine;

namespace MyFps
{
    // 플레이어의 속성, 데이터값을 관리하는 (싱글톤, DontDestroy)클래스...AmmoCount
    public class PlayerStats : PersistentSington<PlayerStats>
    {
        #region Singleton
        // 탄환갯수
        [SerializeField]private int ammoCount;

        public int AmmoCount
        {  
            get { return ammoCount; } 
            private set {ammoCount = value; }
        }
        #endregion

        private void Start()
        {
            // 속성값 data 초기화
            AmmoCount = 0;
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            // 소지갯수
            if (AmmoCount < amount)
            {
                Debug.Log("You need to reload!!!!!!");
                return false;       // 사용량 부족
            }
            
            AmmoCount -= amount;
            
            return true;
        }

    }
}