using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    public GameManager gameManager; //점수와 스테이지 관리
 


    public void StartBtn()
    {
        SceneManager.LoadScene("TalkScene");
    }

    public void OptionBtn()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void OKBtn()
    {
        SceneManager.LoadScene("Stage2GameScene");
      
    }


    public void OK2Btn()
    {
        SceneManager.LoadScene("StartScene");

    }


    public void ExitBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExplainBtn()
    {
        SceneManager.LoadScene("ExplainScene");
    }

    
}
