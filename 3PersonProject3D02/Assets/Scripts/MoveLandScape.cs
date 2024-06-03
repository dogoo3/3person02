using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveLandScape : MonoBehaviour
{
    [Range(10.0f, 100.0f)]
    public float moveSpeed = 30.0f;

    private Vector3 _initPos;

    private void Start()
    {
        _initPos = transform.position;
    }

    private void Update()
    {
        Vector3 t_pos = transform.position;

        t_pos += Vector3.back * moveSpeed * Time.deltaTime;

        transform.position = t_pos;
    }

    public void ResetLandScapePosition()
    {
        transform.position = _initPos;
    }
}
