using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject go;

  
    private bool activated;

    public void Exit()
    {
        Application.Quit();
    }
 
    public void Continue()
    {
        activated = false;
        go.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
       
        if(Input.GetKeyDown("Cancel"))
        {
            activated = !activated;

            if(activated)
            {
                go.SetActive(true);
                Time.timeScale = 0;

            }
            else
            {
                go.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
