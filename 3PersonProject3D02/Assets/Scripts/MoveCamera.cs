using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        // Input의 축을 통해 키보드 입력 값을 가져온다.
        // GetAxis는 점진적 증가/감소, GetAxisRaw는 스위치의 형태로 -1, 0, 1만 존재
        float t_horizontal = Input.GetAxisRaw("Horizontal");
        float t_vertical = Input.GetAxisRaw("Vertical");

        // 카메라 오브젝트의 방향벡터를 가져옴
        Vector3 t_forward = transform.forward;
        Vector3 t_right = transform.right;

        // 벡터의 높이값을 0으로 맞추어 지면과 수평하게 이동할 수 있도록 함
        t_forward.y = 0;
        t_right.y = 0;

        // 이동
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
