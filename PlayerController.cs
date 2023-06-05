using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    //プレイヤーに働くY軸（上下）の力
    float jumpForce = 700.0f;

    //プレイヤーに働くX軸（左右）の力
    float walkForce = 30.0f;

    //プレイヤーのX軸（左右）の最高速度
    float maxWalkSpeed = 3.3f;

    //持ってるキノコの合計値
    int SumMushroom = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            //ジャンプの効果音再生
            GetComponent<AudioSource>().Play();
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤーの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //プレイヤーの速度に応じてアニメーション速度を変える
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //画面外に出た場合はゲームオーバー
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //動く床に乗った時一緒に動く
        if (other.gameObject.tag == "MoveBlock")
        {
            transform.SetParent(other.transform);
        }

        //敵に当たったらゲームオーバー
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }

    //動く床から離れたとき一緒に動くのをやめる
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MoveBlock")
        {
            transform.SetParent(null);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //犬に触れるとクリア画面に映る
        if (other.gameObject.tag == "Dog")
        {
            SceneManager.LoadScene("ClearScene");
        }

        //キノコに触れるとキノコを１個手に入れてキノコobjが消える
        if (other.gameObject.tag == "Mushroom")
        {
            Destroy(other.gameObject);
            SumMushroom += 1;

            //キノコが５個集まるとスケルトンが消える
            if (SumMushroom == 5)
            {
                Destroy(GameObject.Find("Skeleton"));
            }
        }
    }

}
