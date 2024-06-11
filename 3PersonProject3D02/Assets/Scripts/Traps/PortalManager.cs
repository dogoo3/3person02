using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager instance;

    public Material[] trainNumMaterials; // 기차 번호 Material
    public MeshRenderer[] trainNumberObjects; // 기차 번호 오브젝트 2개
    public GameObject[] traps;

    private int _trainNumber = 0; // 현재 호차번호
    private int _loadTrapIndex; // 활성화할 트랩의 번호(나중에 비활성화 해줘야 해서 저장해야 함)
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
        if (RandomTrap()) // 아무런 이변이 없으면
        {
            Debug.Log("이변 없음");
            _isHaveTrap = false;
        }
        else
        {
            _isHaveTrap = true;
            // 이변 랜덤 생성
            _loadTrapIndex = Random.Range(0, traps.Length); // 트랩 번호 랜덤 추출
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Set(); // 트랩 활성화
        }
    }
    // 이변을 생성할지 말지를 정하는 함수
    private bool RandomTrap()
    {
        if (Random.Range(0, 2) == 0)
            return true;
        return false;
    }

    public void PortalCheck(string p_portalArrow)
    {
        if(p_portalArrow == "FrontPortal" && !_isHaveTrap) // 트랩 없이 앞문으로 왔을 때(성공)
        {
            // 호차번호 material 변경
            _trainNumber++;
            foreach(MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
        }
        if(p_portalArrow == "BackPortal" && _isHaveTrap) // 트랩 있이 뒷문으로 왔을 때(성공)
        {
            // 호차번호 material 변경
            _trainNumber++;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
            // 기존에 생성한 트랩 비활성화
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Disable();
        }
        if (p_portalArrow == "FrontPortal" && _isHaveTrap) // 트랩 있이 앞문으로 왔을 때(실패)
        {
            // 호차번호 material 변경
            _trainNumber = 0;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
            // 기존에 생성한 트랩 비활성화
            traps[_loadTrapIndex].GetComponent<TrapInterface>().Disable();
        }
        if (p_portalArrow == "BackPortal" && !_isHaveTrap) // 트랩 없이 뒷문으로 왔을 때(실패)
        {
            // 호차번호 material 변경
            _trainNumber = 0;
            foreach (MeshRenderer i in trainNumberObjects)
                i.material = trainNumMaterials[_trainNumber];
        }
    }
}
