using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapB : MonoBehaviour, TrapInterface
{
    public void Set()
    {
        Debug.Log("B Ȱ��ȭ");
    }

    public void Disable()
    {
        Debug.Log("B ��Ȱ��ȭ");
        gameObject.SetActive(false);
    }
}
