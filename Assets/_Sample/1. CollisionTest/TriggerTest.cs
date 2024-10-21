using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{


    public class TriggerTest : MonoBehaviour
    {
      
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnCollisionEnter:{other.name}");

            // 스페어를 오른쪽으로 힘을 준다, 컬러를 붉게 바꾼다.
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if(moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ChangeRedColor();
            }
          

        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnCollisionStay:{other.name}");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnCollisionExit:{other.name}");

            // 스페어를 오른쪽으로 힘을 준다, 컬러를 오리지날색으로 바꾼다.
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ResetColor();
            }
        }
    }
}