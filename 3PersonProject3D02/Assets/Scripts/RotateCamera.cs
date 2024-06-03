using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("마우스 회전 민감도")]
    [Range(5.0f, 20.0f)] public float moveForce = 5.0f;

    [Header("고개를 올리고 내리는 최대치와 최소치")]
    [Range(-70.0f, -1.0f)] public float rotXmin = -45.0f;
    [Range(1.0f, 70.0f)] public float rotXmax = 45.0f;


    // 이전 프레임의 마우스 위치를 추적하기 위한 좌표 데이터 저장 변수
    private Vector3 _mousePosition;

    // 카메라의 회전 x값과 y값 저장 변수
    private float _cameraRotX, _cameraRotY;

    private Vector3 _cameraRot;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // 프레임 시작 이전 첫 번째 마우스 좌표를 저장
        _mousePosition = Input.mousePosition;
    }

    private void LateUpdate()
    {
        // 현재 프레임의 마우스 커서 좌표와 이전 프레임의 마우스 커서 좌표를 빼서 마우스 좌표의 이동량을 구함
        Vector3 t_mouseDelta = Input.mousePosition - _mousePosition;
    
        if(rotXmin < _cameraRotX + t_mouseDelta.y * -moveForce * Time.deltaTime &&
            _cameraRotX + t_mouseDelta.y * -moveForce * Time.deltaTime < rotXmax)
            _cameraRotX += t_mouseDelta.y * -moveForce * Time.deltaTime;
        _cameraRotY += t_mouseDelta.x * moveForce * Time.deltaTime;

        transform.rotation = Quaternion.Euler(_cameraRotX, _cameraRotY, 0);

        _mousePosition = Input.mousePosition;
    }
}
