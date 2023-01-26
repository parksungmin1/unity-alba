using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{ 
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "StartBtn":
                SceneManager.LoadScene("GameScene");
                break;
        }

    }

}
