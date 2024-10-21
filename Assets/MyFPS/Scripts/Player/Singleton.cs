
using UnityEngine;

namespace MyFps
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get { return instance; }
        }

        public static bool InstanceExist
        {
            get { return Instance != null; }
        }

        protected virtual void Awake() // 상속받으면 오버라이드 가능하게
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = (T)this;

        }

        protected virtual void OnDsetroy()
        {
            if (instance == null)
            {
                instance = null;
            }
        }

    }
}