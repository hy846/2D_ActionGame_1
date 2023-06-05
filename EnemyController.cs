using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //敵のスピード
    [SerializeField] private float _EnemySpeed;

    //敵の行動制限（左端）
    [SerializeField] private float _LeftEdge;

    //敵の行動制限（右端）
    [SerializeField] private float _RightEdge;

    private Vector3 StartPosition;
    private int direction = 1;
    
    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        //右の行動制限に達すると左に移動する
        if (transform.position.x >= _RightEdge)
        {
            direction = -1;
        }

        //左の行動制限に達すると右に移動する
        if (transform.position.x <= _LeftEdge)
        {
            direction = 1;
        }

        //Ｘ軸（左右）に動いた分の距離を足す
        transform.position = new Vector3(transform.position.x + _EnemySpeed * Time.deltaTime * direction, StartPosition.y, StartPosition.z);
    }
}
