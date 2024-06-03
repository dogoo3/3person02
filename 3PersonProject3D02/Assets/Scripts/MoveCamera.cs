using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t_horizontal = Input.GetAxisRaw("Horizontal");
        float t_vertical = Input.GetAxisRaw("Vertical");

        Vector3 t_forward = transform.forward;
        Vector3 t_right = transform.right;

        t_forward.y = 0;
        t_right.y = 0;

        transform.Translate(t_forward * t_vertical * Time.deltaTime * 10.0f, Space.World);
        transform.Translate(t_right * t_horizontal * Time.deltaTime * 10.0f, Space.World);
    }
}
