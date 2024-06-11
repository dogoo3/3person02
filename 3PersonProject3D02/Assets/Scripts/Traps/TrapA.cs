using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapA : MonoBehaviour, TrapInterface
{
    public void Set()
    {
        Debug.Log("A 활성화");
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        Debug.Log("A 비활성화");
        gameObject.SetActive(false);
    }
}
