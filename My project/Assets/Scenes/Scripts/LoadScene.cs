using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public Main main;

    public void Load(int level)
    {
        if (level == 1)
        {
            SceneManager.LoadScene(level);
            main.GetComponent<Main>().PauseOff();
        }

    }
  //  => 
}
