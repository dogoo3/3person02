using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // �÷��̾ üũ�� ������ ��� ������Ʈ
    public Transform rayPos;

    // ���� ������ ���� ��ġ
    public Transform openPos;
    public float moveSpeed = 0.005f;
    public float closeTime = 7.0f;

    private Vector3 _oriPos;
    private bool _isOpen;
    private float _openValue;

    // ���� �ݴ� Ÿ�̹��� ����ϴ� Ÿ�̸� ����
    private float _elapsedTimer;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _oriPos = transform.position;
        _isOpen = false; 
        _openValue = 0f; // ���� ���� ������, 0 ~ 1
        _elapsedTimer = 0f;
    }

    private void Update()
    {
        // �� ������ ���� ������ �����ϴ� �ڵ�
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

        if (_isOpen) // ���� �������� ���� Ÿ�̸Ӱ� �۵��ǰ� �Ѵ�
            _elapsedTimer += Time.deltaTime;
        if (_elapsedTimer > closeTime) // closeTime�ʸ��� Ray�� ���� Player�� üũ
        {
            RaycastHit hit;
            Physics.Raycast(rayPos.position, rayPos.forward, out hit, 9.0f);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("�÷��̾��");
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
        _elapsedTimer = 0f; // Ÿ�̸� �ʱ�ȭ
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
