using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockController : MonoBehaviour
{
    private Vector3 targetpos;

    void Start()
    {
        targetpos = transform.position;
    }

    //左右に動くブロック
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 3.0f + targetpos.x, targetpos.y, targetpos.z);
    }

}
