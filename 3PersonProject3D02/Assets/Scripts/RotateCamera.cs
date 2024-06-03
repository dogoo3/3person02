using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("���콺 ȸ�� �ΰ���")]
    [Range(5.0f, 20.0f)] public float moveForce = 5.0f;

    [Header("���� �ø��� ������ �ִ�ġ�� �ּ�ġ")]
    [Range(-70.0f, -1.0f)] public float rotXmin = -45.0f;
    [Range(1.0f, 70.0f)] public float rotXmax = 45.0f;


    // ���� �������� ���콺 ��ġ�� �����ϱ� ���� ��ǥ ������ ���� ����
    private Vector3 _mousePosition;

    // ī�޶��� ȸ�� x���� y�� ���� ����
    private float _cameraRotX, _cameraRotY;

    private Vector3 _cameraRot;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // ������ ���� ���� ù ��° ���콺 ��ǥ�� ����
        _mousePosition = Input.mousePosition;
    }

    private void LateUpdate()
    {
        // ���� �������� ���콺 Ŀ�� ��ǥ�� ���� �������� ���콺 Ŀ�� ��ǥ�� ���� ���콺 ��ǥ�� �̵����� ����
        Vector3 t_mouseDelta = Input.mousePosition - _mousePosition;
    
        if(rotXmin < _cameraRotX + t_mouseDelta.y * -moveForce * Time.deltaTime &&
            _cameraRotX + t_mouseDelta.y * -moveForce * Time.deltaTime < rotXmax)
            _cameraRotX += t_mouseDelta.y * -moveForce * Time.deltaTime;
        _cameraRotY += t_mouseDelta.x * moveForce * Time.deltaTime;

        transform.rotation = Quaternion.Euler(_cameraRotX, _cameraRotY, 0);

        _mousePosition = Input.mousePosition;
    }
}
