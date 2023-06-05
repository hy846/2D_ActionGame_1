using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    //説明画面へ
    public void StartGame()
    {
        SceneManager.LoadScene("ExplainScene");
    }
}
