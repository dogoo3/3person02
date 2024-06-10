using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveLandScape : MonoBehaviour
{
    [Range(10.0f, 100.0f)]
    public float moveSpeed = 30.0f;

    private Vector3 _initPos;

    private void Start()
    {
        // ù ������ ��ġ�� ����
        _initPos = transform.position;
    }

    private void Update()
    {
        // -1553�̶�� ���ڴ� ��� ���� ���ϱ�?
        // �ͳ� �ȿ� ������ �� ���� ��� ��ǥ
        if(transform.position.z > -1553f)
        {
            Vector3 t_pos = transform.position;

            // ����� ���� �ڷ� �����ϱ� ������ ���⺤�͸� back���� ����
            t_pos += Vector3.back * moveSpeed * Time.deltaTime;

            transform.position = t_pos;
        }
    }

    public void ResetLandScapePosition()
    {
        transform.position = _initPos;
    }
}
