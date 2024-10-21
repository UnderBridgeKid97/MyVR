using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DrawUIAmmo : MonoBehaviour
    {
        #region va

        public TextMeshProUGUI ammoCount;

        #endregion
        // Update is called once per frame
        void Update()
        {
           ammoCount.text=PlayerStats.Instance.AmmoCount.ToString();
            

        }
    }
}