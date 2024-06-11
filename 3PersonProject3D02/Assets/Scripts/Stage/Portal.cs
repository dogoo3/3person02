using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    // 장면 전환 연출을 위한 Image 변수
    public Image image;

    // 배경의 위치를 초기화해주기 위한 변수
    public MoveLandScape movelandscape;
    public Transform characterPos;
    public Transform resetpos;
    public Door[] doors;
    // 포탈 명칭
    public string portalname;

    private bool _isDark, _isLight, _isTimer;
    private float _alpha = 0f, _timer = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _isDark = true;
            image.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(_isDark && _alpha < 1.0f)
        {
            _alpha += 0.02f;
            image.color = new Color(0, 0, 0, _alpha);
            if(_alpha >= 1.0f)
            {
                // 이곳에서 주요한 것들을 Reset해 줌
                // 완전한 암흑 상태를 아주 짧은 시간동안 지속하기 위한 코드
                movelandscape.ResetLandScapePosition();
                // 캐릭터 위치 초기화
                characterPos.position = resetpos.position;
                // PortalManager 스크립트에 값 업데이트 요청
                PortalManager.instance.PortalCheck(portalname);
                PortalManager.instance.MakeCheckRandomTrap();
                // 문 위치 초기화
                foreach(Door i in doors)
                    i.ResetDoor();

                _isTimer = true;
                _isDark = false;
            }
        }
        if(_isTimer)
        {
            _timer += Time.deltaTime;
            if(_timer > 0.5f) // 0.5초가 되는 시점에 다시 밝아짐
            {
                _isLight = true;
                _isTimer = false;
            }
        }
        if(_isLight)
        {
            _alpha -= 0.02f;
            image.color = new Color(0, 0, 0, _alpha);
            if (_alpha <= 0.0f)
            {
                _isLight = false;
                image.gameObject.SetActive(false);
            }
        }
    }


}
