using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDoorSwitch : MonoBehaviour
{
    public Door door;

    private void OnMouseDown()
    {
        float t_distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        Debug.Log(string.Format("�Ÿ� : {0}", t_distance));

        // �÷��̾ �� �տ��� ������ ��ư�� �������� �Ǵ��Ѵ�
        // 3.1�̶�� ����� ���Ƿ� ����ڰ� ������ ��
        if (t_distance < 6.5f)
        {
            door.OpenDoor();
            // �� ���� �Լ��� ������ ����
        }
    }
}
