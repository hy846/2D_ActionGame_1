using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverDirector : MonoBehaviour
{
    //リトライ、説明画面へ
    public void RetryGame()
    {
        SceneManager.LoadScene("ExplainScene");
    }

    //ゲームをやめる、メニュー画面へ
    public void ExitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
