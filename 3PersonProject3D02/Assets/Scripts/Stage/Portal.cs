using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    // ��� ��ȯ ������ ���� Image ����
    public Image image;

    // ����� ��ġ�� �ʱ�ȭ���ֱ� ���� ����
    public MoveLandScape movelandscape;
    public Transform characterPos;
    public Transform resetpos;
    public Door[] doors;
    // ��Ż ��Ī
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
                // �̰����� �ֿ��� �͵��� Reset�� ��
                // ������ ���� ���¸� ���� ª�� �ð����� �����ϱ� ���� �ڵ�
                movelandscape.ResetLandScapePosition();
                // ĳ���� ��ġ �ʱ�ȭ
                characterPos.position = resetpos.position;
                // PortalManager ��ũ��Ʈ�� �� ������Ʈ ��û
                PortalManager.instance.PortalCheck(portalname);
                PortalManager.instance.MakeCheckRandomTrap();
                // �� ��ġ �ʱ�ȭ
                foreach(Door i in doors)
                    i.ResetDoor();

                _isTimer = true;
                _isDark = false;
            }
        }
        if(_isTimer)
        {
            _timer += Time.deltaTime;
            if(_timer > 0.5f) // 0.5�ʰ� �Ǵ� ������ �ٽ� �����
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
