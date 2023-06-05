using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock2Controller : MonoBehaviour
{
    private Vector3 targetpos;

    void Start()
    {
        targetpos = transform.position;
    }

    //上下に動くブロック
    void Update()
    {
        transform.position = new Vector3(targetpos.x, Mathf.Sin(Time.time) * 2.0f + targetpos.y, targetpos.z);
    }

}
