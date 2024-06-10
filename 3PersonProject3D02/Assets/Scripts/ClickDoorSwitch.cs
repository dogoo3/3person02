using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDoorSwitch : MonoBehaviour
{
    public Door door;

    private void OnMouseDown()
    {
        float t_distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        Debug.Log(string.Format("거리 : {0}", t_distance));

        // 플레이어가 문 앞에서 문열림 버튼을 눌렀는지 판단한다
        // 3.1이라는 상수는 임의로 사용자가 설정한 값
        if (t_distance < 6.5f)
        {
            door.OpenDoor();
            // 문 열림 함수를 연결할 예정
        }
    }
}
