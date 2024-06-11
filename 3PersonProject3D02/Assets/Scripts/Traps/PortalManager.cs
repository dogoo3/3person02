using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager instance;

    public Material[] trainNumMaterials; // ���� ��ȣ Material
    public MeshRenderer[] trainNumberObjects; // ���� ��ȣ ������Ʈ 2��
    public GameObject[] traps;

    private int _trainNumber = 0; // ���� ȣ����ȣ
    private int _loadTrapIndex; // Ȱ��ȭ�� Ʈ���� ��ȣ(���߿� ��Ȱ��ȭ ����� �ؼ� �����ؾ� ��)
    private bool _isHaveTrap;

    private void Awake()
    {
        instance = this;        
    }

    private void Start()
    {
        MakeCheckRandomTrap();
    }

    public void MakeCheckRandomTrap()
    {
        if (RandomTrap()) // �ƹ��� �̺��� ������
        {
            Debug.Log("�̺� ����");
            _isHaveTrap = false;
        }
        else
        {
            _isHaveTrap = true;
            // �̺� ���� ����
            _loadTrapIndex = Random.Range(0, traps.Length); // Ʈ�� ��ȣ ���� ����
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Set(); // Ʈ�� Ȱ��ȭ
        }
    }
    // �̺��� �������� ������ ���ϴ� �Լ�
    private bool RandomTrap()
    {
        if (Random.Range(0, 2) == 0)
            return true;
        return false;
    }

    public void PortalCheck(string p_portalArrow)
    {
        if(p_portalArrow == "FrontPortal" && !_isHaveTrap) // Ʈ�� ���� �չ����� ���� ��(����)
        {
            // ȣ����ȣ material ����
            _trainNumber++;
            foreach(MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
        }
        if(p_portalArrow == "BackPortal" && _isHaveTrap) // Ʈ�� ���� �޹����� ���� ��(����)
        {
            // ȣ����ȣ material ����
            _trainNumber++;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
            // ������ ������ Ʈ�� ��Ȱ��ȭ
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Disable();
        }
        if (p_portalArrow == "FrontPortal" && _isHaveTrap) // Ʈ�� ���� �չ����� ���� ��(����)
        {
            // ȣ����ȣ material ����
            _trainNumber = 0;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
            // ������ ������ Ʈ�� ��Ȱ��ȭ
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Disable();
        }
        if (p_portalArrow == "BackPortal" && !_isHaveTrap) // Ʈ�� ���� �޹����� ���� ��(����)
        {
            // ȣ����ȣ material ����
            _trainNumber = 0;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
        }
    }
}
