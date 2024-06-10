using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("마우스 회전 민감도")]
    [Range(100.0f, 200.0f)] public float moveForce = 5.0f;

    [Header("고개를 올리고 내리는 최대치와 최소치")]
    [Range(-70.0f, -1.0f)] public float rotXmin = -45.0f;
    [Range(1.0f, 70.0f)] public float rotXmax = 45.0f;


    // 이전 프레임의 마우스 위치를 추적하기 위한 좌표 데이터 저장 변수
    private Vector3 _mousePosition;

    // 카메라의 회전 x값과 y값 저장 변수
    private Vector3 _cameraRot;

    private void Start()
    {
        // 프레임 시작 이전 첫 번째 마우스 좌표를 저장
        _mousePosition.x = Input.GetAxis("Mouse X");
        _mousePosition.y = Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
        // 현재 프레임의 마우스 커서 좌표와 이전 프레임의 마우스 커서 좌표를 빼서 마우스 좌표의 이동량을 구함
        Vector3 t_mouseDelta = Vector3.zero;

        t_mouseDelta.x = Input.GetAxis("Mouse X");
        t_mouseDelta.y = Input.GetAxis("Mouse Y");

        // 이전 마우스 위치와 현재 마우스 위치의 변위값이 일정 값 이내여야만
        // 카메라를 회전시킨다.
        if (Vector3.Distance(t_mouseDelta, _mousePosition) < 5.0f)
        {

            // 마우스 좌표의 이동량만큼 더했을 때 허용치 내에 존재할 때에만 값을 변경하도록 함
            if (rotXmin < _cameraRot.x + t_mouseDelta.y * -moveForce * Time.deltaTime &&
                _cameraRot.x + t_mouseDelta.y * -moveForce * Time.deltaTime < rotXmax)
                _cameraRot.x += t_mouseDelta.y * -moveForce * Time.deltaTime;
            _cameraRot.y += t_mouseDelta.x * moveForce * Time.deltaTime;

            transform.rotation = Quaternion.Euler(_cameraRot);

            _mousePosition = Input.mousePosition;

            _mousePosition.x = Input.GetAxis("Mouse X");
            _mousePosition.y = Input.GetAxis("Mouse Y");
        }
    }
}
