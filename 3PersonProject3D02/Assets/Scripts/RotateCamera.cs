using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("���콺 ȸ�� �ΰ���")]
    [Range(100.0f, 200.0f)] public float moveForce = 5.0f;

    [Header("���� �ø��� ������ �ִ�ġ�� �ּ�ġ")]
    [Range(-70.0f, -1.0f)] public float rotXmin = -45.0f;
    [Range(1.0f, 70.0f)] public float rotXmax = 45.0f;


    // ���� �������� ���콺 ��ġ�� �����ϱ� ���� ��ǥ ������ ���� ����
    private Vector3 _mousePosition;

    // ī�޶��� ȸ�� x���� y�� ���� ����
    private Vector3 _cameraRot;

    private void Start()
    {
        // ������ ���� ���� ù ��° ���콺 ��ǥ�� ����
        _mousePosition.x = Input.GetAxis("Mouse X");
        _mousePosition.y = Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
        // ���� �������� ���콺 Ŀ�� ��ǥ�� ���� �������� ���콺 Ŀ�� ��ǥ�� ���� ���콺 ��ǥ�� �̵����� ����
        Vector3 t_mouseDelta = Vector3.zero;

        t_mouseDelta.x = Input.GetAxis("Mouse X");
        t_mouseDelta.y = Input.GetAxis("Mouse Y");

        // ���� ���콺 ��ġ�� ���� ���콺 ��ġ�� �������� ���� �� �̳����߸�
        // ī�޶� ȸ����Ų��.
        if (Vector3.Distance(t_mouseDelta, _mousePosition) < 5.0f)
        {

            // ���콺 ��ǥ�� �̵�����ŭ ������ �� ���ġ ���� ������ ������ ���� �����ϵ��� ��
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
