using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // 플레이어를 체크할 광선을 쏘는 오브젝트
    public Transform rayPos;

    // 문이 열렸을 때의 위치
    public Transform openPos;
    public float moveSpeed = 0.005f;
    public float closeTime = 7.0f;

    private Vector3 _oriPos;
    private bool _isOpen;
    private float _openValue;

    // 문을 닫는 타이밍을 계산하는 타이머 변수
    private float _elapsedTimer;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _oriPos = transform.position;
        _isOpen = false; 
        _openValue = 0f; // 문이 열린 정도값, 0 ~ 1
        _elapsedTimer = 0f;
    }

    private void Update()
    {
        // 문 열림과 닫힘 동작을 실행하는 코드
        if(_isOpen && _openValue < 1.0f)
        {
            _openValue += moveSpeed;
            transform.position = Vector3.Lerp(_oriPos, openPos.position, _openValue);
        }
        if(!_isOpen && _openValue > 0f)
        {
            _openValue -= moveSpeed;
            transform.position = Vector3.Lerp(_oriPos, openPos.position, _openValue);
        }

        if (_isOpen) // 문이 열려있을 때만 타이머가 작동되게 한다
            _elapsedTimer += Time.deltaTime;
        if (_elapsedTimer > closeTime) // closeTime초마다 Ray를 쏴서 Player를 체크
        {
            RaycastHit hit;
            Physics.Raycast(rayPos.position, rayPos.forward, out hit, 9.0f);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("플레이어감지");
                    _elapsedTimer = 0f;
                }
                else
                {
                    _isOpen = false;
                    _elapsedTimer = 0f;
                }
            }
            else
            {
                _isOpen = false;
                _elapsedTimer = 0f;
            }
        }
    }

    public void OpenDoor()
    {
        _elapsedTimer = 0f; // 타이머 초기화
        _isOpen = true;
    }

    public void ResetDoor()
    {
        transform.position = _oriPos;
        _elapsedTimer = 0;
        _isOpen = false;
        _openValue = 0;
    }
}
