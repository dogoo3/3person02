using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapA : MonoBehaviour, TrapInterface
{
    public void Set()
    {
        Debug.Log("A Ȱ��ȭ");
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        Debug.Log("A ��Ȱ��ȭ");
        gameObject.SetActive(false);
    }
}
