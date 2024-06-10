using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        // Input�� ���� ���� Ű���� �Է� ���� �����´�.
        // GetAxis�� ������ ����/����, GetAxisRaw�� ����ġ�� ���·� -1, 0, 1�� ����
        float t_horizontal = Input.GetAxisRaw("Horizontal");
        float t_vertical = Input.GetAxisRaw("Vertical");

        // ī�޶� ������Ʈ�� ���⺤�͸� ������
        Vector3 t_forward = transform.forward;
        Vector3 t_right = transform.right;

        // ������ ���̰��� 0���� ���߾� ����� �����ϰ� �̵��� �� �ֵ��� ��
        t_forward.y = 0;
        t_right.y = 0;

        // �̵�
        if (t_vertical != 0)
        {
            Debug.DrawRay(transform.position + Vector3.down * 7.0f, transform.forward * t_vertical, Color.green, 1.0f);
            if(!Physics.Raycast(transform.position + Vector3.down * 7.0f, transform.forward * t_vertical, 2.0f))
                transform.parent.Translate(t_forward * t_vertical * Time.deltaTime * moveSpeed, Space.World);
        }

        if(t_horizontal != 0)
        {
            if (!Physics.Raycast(transform.position + Vector3.down * 7.0f, transform.right * t_horizontal, 2.0f))
                transform.parent.Translate(t_right * t_horizontal * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}
