using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapB : MonoBehaviour, TrapInterface
{
    public void Set()
    {
        Debug.Log("B 활성화");
    }

    public void Disable()
    {
        Debug.Log("B 비활성화");
        gameObject.SetActive(false);
    }
}
