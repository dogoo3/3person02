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
        // 첫 시작점 위치를 저장
        _initPos = transform.position;
    }

    private void Update()
    {
        // -1553이라는 숫자는 어디서 나온 것일까?
        // 터널 안에 기차가 들어갈 때의 배경 좌표
        if(transform.position.z > -1553f)
        {
            Vector3 t_pos = transform.position;

            // 배경이 점점 뒤로 가야하기 때문에 방향벡터를 back으로 설정
            t_pos += Vector3.back * moveSpeed * Time.deltaTime;

            transform.position = t_pos;
        }
    }

    public void ResetLandScapePosition()
    {
        transform.position = _initPos;
    }
}
