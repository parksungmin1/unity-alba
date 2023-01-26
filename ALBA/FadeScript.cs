using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    float fades = 1.0f;
    float time = 0;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(fades > 0.0f && time >= 0.1                                                                    f)
        {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }else if(fades<=0.0f){
            time = 0;
        }
    }
}
